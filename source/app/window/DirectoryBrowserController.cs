using System;

namespace app.window
{
    public class DirectoryBrowserController : IBrowserDirectory
    {

        private readonly IDirectoryFind directoryFind;

        public DirectoryBrowserController(IDirectoryFind directoryFind)
        {
            this.directoryFind = directoryFind;
        }

        public void browse_directory(string path)
        {
            this.directoryFind.get_directory_info(path);
        }
    }
}