using System.Windows.Forms;

namespace app.windows
{
  public class ExpandableDirectoryBrowsingNode
  {
    TreeView tree;
    ICreateNodes node_factory;
    IGetData node_data;
    IDetermineIfANodeNeedsToBeReloaded node_reload_specification;


    public ExpandableDirectoryBrowsingNode(TreeView tree, ICreateNodes node_factory, IGetData node_data, IDetermineIfANodeNeedsToBeReloaded node_reload_specification)
    {
      this.tree = tree;
      this.node_factory = node_factory;
      this.node_data = node_data;
      this.node_reload_specification = node_reload_specification;

      this.tree.BeforeExpand += (sender, e) => load_child_data(e);
    }

    void load_child_data(TreeViewCancelEventArgs e)
    {
      var node = e.Node;
      if (node_reload_specification(node)) reload_node(node);
    }

    void reload_node(TreeNode node)
    {
      node.Nodes.Clear();
      var entries = node_data.get_directory_entries(node.Text);
      foreach (var entry in entries)
      {
        var new_node = node_factory.create_node(entry);
        node.Nodes.Add(new_node);
      }
    }

  }
}