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

      var buttonSwitcher = new ButtonSwitcher(view.button3, new[] {view.button1, view.button2});
      new ClickTriggeredAction(buttonSwitcher, view.button3);

      Application.Run(view);
    }
  }
}