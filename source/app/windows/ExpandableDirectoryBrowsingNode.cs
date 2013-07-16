using System.Windows.Forms;

namespace app.windows
{
  public class ExpandableDirectoryBrowsingNode
  {
    TreeView tree;
    ICreateFileBrowserNodes node_factory;
    IGetDirectoryEntries node_data;

    public ExpandableDirectoryBrowsingNode(TreeView tree, ICreateFileBrowserNodes node_factory, IGetDirectoryEntries node_data)
    {
      this.tree = tree;
      this.node_factory = node_factory;
      this.node_data = node_data;

      this.tree.BeforeExpand += (sender, e) => load_child_data(e);
    }

    void load_child_data(TreeViewCancelEventArgs e)
    {
      var node = e.Node;
      if (requires_loading(node)) reload_node(node);
    }

    void reload_node(TreeNode node)
    {
      node.Nodes.Clear();
      var child_data = node_data.get_child_data_for(node.Text);
      foreach (var child_text in child_data)
      {
        var new_node = node_factory.create_node(child_text);
        node.Nodes.Add(new_node);
      }
    }

    bool requires_loading(TreeNode node)
    {
      return node.FirstNode == DummyNode.instance;
    }
  }
}