namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    public IProcessOneRequest get_command_that_can_process(IContainRequestInformation request)
    {
      throw new System.NotImplementedException();
    }
  }
}