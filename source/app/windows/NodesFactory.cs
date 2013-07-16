using System.Windows.Forms;

namespace app.windows
{
    public class NodesFactory: ICreateNodes
    {
        private IDetermineIfANodeIsADirectory isADirectory;
        private IGetDisplayNodeName getDisplayNodeName;

        public NodesFactory(IDetermineIfANodeIsADirectory isADirectory, IGetDisplayNodeName getDisplayNodeName)
        {
            this.isADirectory = isADirectory;
            this.getDisplayNodeName = getDisplayNodeName;
        }

        public TreeNode create_node(string directory_entry)
        {
            var node = new TreeNode(getDisplayNodeName(directory_entry));
            node.Tag = directory_entry;
            if (this.isADirectory(directory_entry))
                node.Nodes.Add(DummyNode.NODE_TEXT);

            return node;
        }
    }
}