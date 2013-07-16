using System.Collections.Generic;

namespace app.windows
{
  public interface IGetDirectoryEntries
  {
    IEnumerable<string> get_child_data_for(string data);
  }
}