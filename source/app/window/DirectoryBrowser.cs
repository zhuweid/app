using System.Windows.Forms;
using app.core;

namespace app.window
{
  public class DirectoryBrowser : IDirectoryBrowser, IRun
  {
    TreeView tree_view;
    TextBox path_text_box;

    public DirectoryBrowser(TextBox path_text_box, TreeView tree_view)
    {
      this.path_text_box = path_text_box;
      this.tree_view = tree_view;
    }

    public void initialize()
    {
      var node = tree_view.Nodes.Add(path_text_box.Text);
      node.Nodes.Add("Dummy");
    }

    public void run()
    {
      initialize();
    }
  }
}