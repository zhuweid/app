namespace app.web.core
{
  public interface IProcessOneRequest 
  {
    void process(IContainRequestInformation request);
    bool can_process(IContainRequestInformation request);
  }


}