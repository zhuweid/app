using System.Windows.Forms;
using Machine.Specifications;
using app.windows;
using developwithpassion.specifications.rhinomocks;

namespace app.specs.windows
{
  [Subject(typeof(UI))]
  public class NodeThatNeedsToBeReloadedSpecs
  {
    public abstract class concern : Observes<UI>
    {
    }

    public class when_determining_if_a_node_should_be_reloaded : concern
    {
      Because b = () =>
        result = UI.node_requires_reload(node);

      public class and_the_nodes_child_node_text_is_the_dummy_node_text
      {
        Establish c = () =>
        {
          node = new TreeNode("Whatever");
          node.Nodes.Add(DummyNode.NODE_TEXT);
        };

        It should_match = () =>
          result.ShouldBeTrue();
      }

      public class and_the_nodes_text_is_not_the_dummy_node_text
      {
        Establish c = () =>
        {
          node = new TreeNode("Anything else");
          node.Nodes.Add("Whatever");
        };

        It should_not_match = () =>
          result.ShouldBeFalse();
      }

      static bool result;
      static TreeNode node;
    }
  }
}