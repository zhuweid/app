using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentInTheStore : IImplementAFeature
  {
      private readonly IFindDepartments departmentFinder;

      public ViewTheMainDepartmentInTheStore(IFindDepartments departmentFinder)
      {
          this.departmentFinder = departmentFinder;
      }

    public void process(IContainRequestInformation request)
    {
        departmentFinder.get_the_main_departments();
    }
  }
}