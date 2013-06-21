namespace app.web.core
{
  public class RequestCommand: IProcessOneRequest
  {
    IMatchAReqest request_specification;
    IImplementAFeature feature;

    public RequestCommand(IMatchAReqest request_specification, IImplementAFeature feature)
    {
      this.request_specification = request_specification;
      this.feature = feature;
    }

    public void process(IContainRequestInformation request)
    {
      feature.process(request);
    }

    public bool can_process(IContainRequestInformation request)
    {
      return request_specification(request);
    }
  }

}