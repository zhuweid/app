using System;
using System.Collections.Generic;
using System.Linq;
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

      var node_factory = new StubNodeFactory();
      var browser = new DirectoryBrowser(view.textBox1, view.treeView1,node_factory);
      var action = new StateAwareAction(browser);

      new ExpandableDirectoryBrowsingNode(view.treeView1, node_factory,
                                                                       new StubData(),
                                                                       UI.node_requires_reload);
      new ClickTriggeredAction(action, view.button1);
      new ClickTriggeredAction(action, view.button2);

      Application.Run(view);
    }

    public class StubData : IGetData
    {
      public IEnumerable<string> get_directory_entries(string data)
      {
        return Enumerable.Range(1, 10).Select(x => x.ToString());
      }
    }

    public class StubNodeFactory : ICreateNodes
    {
      static int key = 0;
      public TreeNode create_node(string text)
      {
        var node = new TreeNode(string.Format("{0} - {1}", text, ++key));
        node.Nodes.Add(DummyNode.NODE_TEXT);
        return node;
      }
    }

    static IRun create_runnable_action(Action action)
    {
      return new AnonymousAction(action);
    }
  }
}