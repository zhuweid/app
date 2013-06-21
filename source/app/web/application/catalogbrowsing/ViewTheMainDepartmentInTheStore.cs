using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentInTheStore : IImplementAFeature
  {
    IFindDepartments department_repository;
    IDisplayInformation display_engine;

      public ViewTheMainDepartmentInTheStore(IFindDepartments department_repository, IDisplayInformation display_engine)
    {
      this.department_repository = department_repository;
      this.display_engine = display_engine;
    }

    public void process(IContainRequestInformation request)
    {
      var departments = department_repository.get_the_main_departments();
      display_engine.display_the_main_departments(departments);
    }
  }
}