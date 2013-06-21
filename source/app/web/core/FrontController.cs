namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
      private readonly IFindCommands _commandFinder;

      public FrontController(IFindCommands commandFinder)
    {
        _commandFinder = commandFinder;
    }
    
     public void process(IContainRequestInformation request)
    {
      _commandFinder.get_command_that_can_process(request).process(request);
    }
  }
}