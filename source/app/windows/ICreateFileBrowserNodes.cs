using System.Windows.Forms;

namespace app.windows
{
  public interface ICreateFileBrowserNodes
  {
    TreeNode create_node(string text); 
  }
}