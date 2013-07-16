using System.Windows.Forms;

namespace app.window
{
  public interface IDisplayDirectoryHierarchies
  {
    TextBox path_text_box { get; }
    Button start_search_button { get; }
    TreeView directory_tree { get; }
  }
}