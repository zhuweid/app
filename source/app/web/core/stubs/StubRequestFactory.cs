using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IContainRequestInformation create_request_from(HttpContext asp_net_context)
    {
      return new StubRequest();
    }

    class StubRequest : IContainRequestInformation
    {
    }
  }
}