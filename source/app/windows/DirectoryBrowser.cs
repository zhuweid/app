using System.Windows.Forms;
using app.core;

namespace app.windows
{
  public class DirectoryBrowser : IDirectoryBrowser, IRun
  {
    TreeView tree_view;
    TextBox path_text_box;
    ICreateNodes node_factory;

    public DirectoryBrowser(TextBox path_text_box, TreeView tree_view, ICreateNodes node_factory)
    {
      this.path_text_box = path_text_box;
      this.tree_view = tree_view;

      this.node_factory = node_factory;
    }

    public void initialize()
    {
      tree_view.Nodes.Clear();
      var node = node_factory.create_node(path_text_box.Text);
      tree_view.Nodes.Add(node);
    }

    public void run()
    {
      initialize();
    }

    
  }
}