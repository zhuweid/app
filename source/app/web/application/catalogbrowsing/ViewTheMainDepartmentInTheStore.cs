using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentInTheStore : IImplementAFeature
  {
      private IFindDepartments department_repository;

      public ViewTheMainDepartmentInTheStore(IFindDepartments departmentRepository)
      {
          department_repository = departmentRepository;
      }

      public void process(IContainRequestInformation request)
    {
      department_repository.get_the_main_departments();
    }
  }
}