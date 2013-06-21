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
        request = fake.an<IContainRequestInformation>();
      };

      Because b = () =>
        sut.process(request);

      It should_get_the_list_of_the_main_departments = () =>
        department_repository.received(x => x.get_the_main_departments());

      static IFindDepartments department_repository;
      static IContainRequestInformation request;
    }
  }
}
