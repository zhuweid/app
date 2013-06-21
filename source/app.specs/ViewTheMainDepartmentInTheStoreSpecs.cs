 using System.Collections.Generic;
 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ViewTheMainDepartmentInTheStore))]  
  public class ViewTheMainDepartmentInTheStoreSpecs
  {
    public abstract class concern : Observes<IImplementAFeature,
                                      ViewTheMainDepartmentInTheStore>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        department_repository = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        request = fake.an<IContainRequestInformation>();
        main_departments = new List<Department> {new Department()};

        department_repository.setup(x => x.get_the_main_departments()).Return(main_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_main_departments = () =>
        display_engine.received(x => x.display(main_departments));

      static IFindDepartments department_repository;
      static IContainRequestInformation request;
      static IDisplayInformation display_engine;
      static IEnumerable<Department> main_departments;
    }
  }
}
