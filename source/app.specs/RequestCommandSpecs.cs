 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(RequestCommand))]  
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
        
    }

   
    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        depends.on<IMatchAReqest>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });

        request = fake.an<IContainRequestInformation>();
      };

      Because b = () =>
        result = sut.can_process(request);

      It should_make_the_determination_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static bool result;
      static IContainRequestInformation request;
    }

    public class when_processing_the_request : concern
    {
      Establish c = () =>
      {
        application_feature = depends.on<IImplementAFeature>();
        request = fake.an<IContainRequestInformation>();
      };
      Because b = () =>
        sut.process(request);

      It should_delegate_processing_to_the_application_feature = () =>
        application_feature.received(x => x.process(request));

      static IImplementAFeature application_feature;
      static IContainRequestInformation request;
    }

  }
}
