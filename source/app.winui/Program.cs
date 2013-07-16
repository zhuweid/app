using System;
using System.Windows.Forms;
using app.window;

namespace app.winui
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var view = new DirectoryBrowserView();
      var browser = new DirectoryBrowser(view.textBox1, view.treeView1);
      new ButtonTriggeredAction(browser, view.button1);

      Application.Run(view);
    }
  }
}