using System;
using System.Windows.Forms;
using app.core;
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
      var action = new StateAwareAction(browser);

      new ClickTriggeredAction(action, view.button1);
      new ClickTriggeredAction(action, view.button2);


      Application.Run(view);
    }

    static IRun create_runnable_action(Action action)
    {
      return new AnonymousAction(action); 
    }

  }
}