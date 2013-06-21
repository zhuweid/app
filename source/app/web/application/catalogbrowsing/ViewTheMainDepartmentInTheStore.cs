using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

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

    public ViewTheMainDepartmentInTheStore():this(new StubDepartmentRepository(),
      new StubDisplayEngine())
    {
    }

    public void process(IContainRequestInformation request)
    {
      var main_departments = department_repository.get_the_main_departments();

      display_engine.display(main_departments);
    }
  }
}