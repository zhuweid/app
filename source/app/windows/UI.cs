namespace app.windows
{
  public class UI
  {
    public static IDetermineIfANodeNeedsToBeReloaded node_requires_reload = (node) => node.Text == DummyNode.NODE_TEXT;
  }
}