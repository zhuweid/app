using System.IO;

namespace app.windows
{
    public class UI
    {
        public static IDetermineIfANodeNeedsToBeReloaded node_requires_reload = (node) =>
                                                                                    {
                                                                                        return node.Nodes.Count > 0 &&
                                                                                               node.FirstNode.Text ==
                                                                                               DummyNode.NODE_TEXT;
                                                                                    };

        public static bool DetermineIfANodeIsADirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            //detect whether its a directory or file
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }

        public static string GetDisplayNodeName(string path)
        {
            string fileName = Path.GetFileName(path);
            if (string.IsNullOrEmpty(fileName))
                //return Path.GetDirectoryName(path);
                return path;

            return fileName;
        }
    }
}