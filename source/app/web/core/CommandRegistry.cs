using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands)
    {
      this.commands = commands;
    }

    public IProcessOneRequest get_command_that_can_process(IContainRequestInformation request)
    {
      var command = commands.First(c => c.can_process(request));

      return command;
    }
  }
}