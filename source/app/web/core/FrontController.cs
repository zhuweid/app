namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
    IFindCommands command_registry;
      private ISecurityProvider security_provider;

      public FrontController(IFindCommands command_registry, ISecurityProvider security_provider)
    {
      this.command_registry = command_registry;
          this.security_provider = security_provider;
    }

    public FrontController():this(new CommandRegistry(), new SecurityProvider())
    {
    }

    public void process(IContainRequestInformation request)
    {
        if (security_provider.Qualify())
        {
            var command = command_registry.get_command_that_can_process(request);
            command.process(request);
        }
    }
  }
}