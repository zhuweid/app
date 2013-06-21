using System;
using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
    ICreateTheMissingCommand missing_command_factory;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands, ICreateTheMissingCommand missing_command_factory)
    {
      this.commands = commands;
      this.missing_command_factory = missing_command_factory;
    }

    public CommandRegistry():this(new StubSetOfCommands(), x =>
    {
      throw new NotImplementedException("There is no command to handle this request");
    })
    {
    }

    public IProcessOneRequest get_command_that_can_process(IContainRequestInformation request)
    {
      var command = commands.FirstOrDefault(c => c.can_process(request));

      return command ?? missing_command_factory(request);
    }
  }
}