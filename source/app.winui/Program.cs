using System;
using System.Windows.Forms;
using app.windows;

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
      new ClickTriggeredAction(browser, view.button1);
      new ClickTriggeredAction(browser, view.button2);

      Application.Run(view);
    }
  }
}