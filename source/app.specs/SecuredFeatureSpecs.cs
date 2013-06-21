 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(SecuredFeature))]  
  public class SecuredFeatureSpecs
  {
    public abstract class concern : Observes<IImplementAFeature,
                                      SecuredFeature>
    {
        
    }

   
    public class when_run : concern
    {
      public class and_the_security_constraint_is_satisfied
      {
        Establish c = () =>
        {
          depends.on<IVerifyASecurityConstraint>(() => true);
          actual_feature = depends.on<IImplementAFeature>();
          request = fake.an<IContainRequestInformation>();
        };

        Because b = () =>
          sut.process(request);

        It should_run_the_actual_feature = () =>
          actual_feature.received(x => x.process(request));

        static IImplementAFeature actual_feature;
        static IContainRequestInformation request;
      }
        
        
    }
  }
}
