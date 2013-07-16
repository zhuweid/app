using System.Windows.Forms;
using Machine.Specifications;
using app.windows;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs.windows
{
  [Subject(typeof(DirectoryBrowser))]
  public class DirectoryBrowserSpecs
  {
    public abstract class concern : Observes<IDirectoryBrowser,
                                      DirectoryBrowser>
    {
    }

    public class when_displaying_the_initial_folder_hierarchy : concern
    {
      Establish c = () =>
      {
        path_text_box = new TextBox();
        tree_view = new TreeView();
        node = new TreeNode();
        node_factory = depends.on<ICreateNodes>();
        depends.on(path_text_box);
        depends.on(tree_view);

        path_text_box.Text = "blah";

        node_factory.setup(x => x.create_node("blah")).Return(node);
      };

      Because b = () =>
        sut.initialize();

      It should_display_the_initial_node = () =>
        tree_view.Nodes[0].ShouldEqual(node);

      static TreeView tree_view;
      static TextBox path_text_box;
      static ICreateNodes node_factory;
      static TreeNode node;
    }

    public class when_initialized_multiple_times : concern
    {
      Establish c = () =>
      {
        path_text_box = new TextBox();
        tree_view = new TreeView();
        path_text_box.Text = "blah";

        depends.on(path_text_box);
        depends.on(tree_view);
      };

      Because b = () =>
      {
        sut.initialize();
        sut.initialize();
      };

      It should_clear_out_the_treeview_prior_to_displaying_the_new_node = () =>
        tree_view.Nodes.Count.ShouldEqual(1);

      static TreeView tree_view;
      static TextBox path_text_box;
      static Button button;
    }
  }
}