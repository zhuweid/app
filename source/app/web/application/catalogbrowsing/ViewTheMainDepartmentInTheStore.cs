using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentInTheStore : IImplementAFeature
  {
    IFindDepartments department_repository;

    public ViewTheMainDepartmentInTheStore(IFindDepartments department_repository)
    {
      this.department_repository = department_repository;
    }

    public void process(IContainRequestInformation request)
    {
      department_repository.get_the_main_departments();
    }
  }
}