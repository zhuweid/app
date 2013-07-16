using System.Windows.Forms;
using Machine.Specifications;
using app.windows;
using developwithpassion.specifications.rhinomocks;

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
        path_text_box.Text = "blah";

        depends.on(path_text_box);
        depends.on(tree_view);
      };

      Because b = () =>
        sut.initialize();

      It should_display_the_specified_directory_in_the_directory_tree = () =>
        tree_view.Nodes[0].Text.ShouldEqual(path_text_box.Text);

      It should_display_a_node_that_is_collapsible = () =>
        tree_view.Nodes[0].Nodes.Count.ShouldBeGreaterThan(0);

      static IDisplayDirectoryHierarchies browser;
      static TreeView tree_view;
      static TextBox path_text_box;
      static Button button;
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

      static IDisplayDirectoryHierarchies browser;
      static TreeView tree_view;
      static TextBox path_text_box;
      static Button button;
    }
  }
}