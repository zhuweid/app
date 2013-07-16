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

    public class when_the_node_is_expanded : concern
    {
      Establish c = () =>
      {
        tree = new TreeView();
        node = new TreeNode();
        child_node = new TreeNode();
        node_factory = depends.on<ICreateFileBrowserNodes>();
        node_child_data = depends.on<IGetDirectoryEntries>();
        node.Nodes.Add(DummyNode.instance);
        tree.Nodes.Add(node);

        node_factory.setup(x => x.create_node(Arg<string>.Is.Anything)).Return(child_node);
        node_child_data.setup(x => x.get_child_data_for(node.Text)).Return(Enumerable.Range(1,10).Select(x => x.ToString()));

        depends.on(tree);
      };

      Because b = () =>
        Events.raise_event(tree, "BeforeExpand", new TreeViewCancelEventArgs(node, false, TreeViewAction.Expand));

      It should_remove_the_dummy_node = () =>
        node.Nodes.ShouldNotContain(DummyNode.instance);

      It should_populate_the_node_with_child_data = () =>
      {
        node.Nodes.Count.ShouldEqual(10);
        foreach (var new_node in node.Nodes)
        {
          new_node.ShouldEqual(child_node);
        }
      };
        

      static TreeView tree;
      static System.Windows.Forms.TreeNode node;
      static ICreateFileBrowserNodes node_factory;
      static TreeNode child_node;
      static IGetDirectoryEntries node_child_data;
    }
  }
}