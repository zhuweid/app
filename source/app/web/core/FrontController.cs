namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
      private readonly IFindCommands commandRegistry;

      public FrontController(IFindCommands commandRegistry)
      {
          this.commandRegistry = commandRegistry;
      }

      public void process(IContainRequestInformation request)
      {
          var processOnRequest = commandRegistry.get_command_that_can_process(request);
          processOnRequest.process(request);
      }
  }
}