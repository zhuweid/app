namespace app.windows
{
  public class UI
  {
    public static IDetermineIfANodeNeedsToBeReloaded node_requires_reload = (node) =>
    {
      return node.Nodes.Count > 0 && node.FirstNode.Text == DummyNode.NODE_TEXT;
    };
  }
}