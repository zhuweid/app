using System.Collections.Generic;

namespace app.windows
{
  public interface IGetData
  {
    IEnumerable<string> get_directory_entries(string path);
  }
}