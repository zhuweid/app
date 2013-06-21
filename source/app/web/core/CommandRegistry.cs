using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
    ICreateTheMissingRequestCommand missingRequestCommand;

      public CommandRegistry(IEnumerable<IProcessOneRequest> commands, ICreateTheMissingRequestCommand missingRequestCommand)
    {
      this.commands = commands;
      this.missingRequestCommand = missingRequestCommand;
    }

    public IProcessOneRequest get_command_that_can_process(IContainRequestInformation request)
    {
      var command = commands.FirstOrDefault(c => c.can_process(request));

        if (command == null)
            return missingRequestCommand(request);

      return command;
    }
  }
}