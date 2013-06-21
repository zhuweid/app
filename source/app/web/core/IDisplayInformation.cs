using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
  public interface IDisplayInformation
  {
    void display_the_main_departments(IEnumerable<Department> main_departments);
  }
}