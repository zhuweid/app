using System.Web;

namespace app.web.core.aspnet
{
  public class RawAspNetHandler : IHttpHandler
  {
    IProcessRequests front_controller;
    ICreateRequests request_factory;

    public RawAspNetHandler(IProcessRequests front_controller, ICreateRequests request_factory)
    {
      this.front_controller = front_controller;
      this.request_factory = request_factory;
    }

    public bool IsReusable
    {
      get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
      var request = request_factory.create_request_from(context);
      front_controller.process(request);
    }
  }
}