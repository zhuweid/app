using System.Linq;
using System.Windows.Forms;
using Machine.Specifications;
using Rhino.Mocks;
using app.specs.utility;
using app.windows;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs.windows
{
  [Subject(typeof(ExpandableDirectoryBrowsingNode))]
  public class ExpandableDirectoryBrowsingNodeSpecs
  {
    public abstract class concern : Observes<ExpandableDirectoryBrowsingNode>
    {
    }

    public class when_a_directory_browsing_node_is_expanded : concern
    {
      Establish c = () =>
      {
        tree = new TreeView();
        node_to_expand = new TreeNode();
        child_node = new TreeNode();

        node_factory = depends.on<ICreateNodes>();
        node_child_data = depends.on<IGetData>();
        depends.on<IDetermineIfANodeNeedsToBeReloaded>(x => true);

        tree.Nodes.Add(node_to_expand);

        node_factory.setup(x => x.create_node(Arg<string>.Is.Anything)).Return(child_node);
        node_child_data.setup(x => x.get_directory_entries(node_to_expand.Text)).Return(Enumerable.Range(1,10).Select(x => x.ToString()));

        depends.on(tree);
      };

      Because b = () =>
        Events.raise_event(tree, "BeforeExpand", new TreeViewCancelEventArgs(node_to_expand, false, TreeViewAction.Expand));


      It should_populate_the_node_with_directory_information = () =>
      {
        node_to_expand.Nodes.Count.ShouldEqual(10);
        foreach (var new_node in node_to_expand.Nodes)
        {
          new_node.ShouldEqual(child_node);
        }
      };
        

      static TreeView tree;
      static System.Windows.Forms.TreeNode node_to_expand;
      static ICreateNodes node_factory;
      static TreeNode child_node;
      static IGetData node_child_data;
    }
  }
}