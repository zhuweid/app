using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(RawAspNetHandler))]
  public class RawAspNetHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      RawAspNetHandler>
    {
    }

    public class when_handling_an_asp_net_context  : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateRequests>();
        asp_net_context = ObjectFactory.web.create_http_context();

        request_factory.setup(x => x.create_request_from(asp_net_context)).Return(request);
      };
      Because b = () =>
        sut.ProcessRequest(asp_net_context);

      It should_delegate_processing_of_a_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(request));

      static IProcessRequests front_controller;
      static IContainRequestInformation request;
      static HttpContext asp_net_context;
      static ICreateRequests request_factory;
    }
  }
}