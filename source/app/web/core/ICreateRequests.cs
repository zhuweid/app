using System.Web;

namespace app.web.core
{
  public interface ICreateRequests
  {
    IContainRequestInformation create_request_from(HttpContext asp_net_context);
  }
}