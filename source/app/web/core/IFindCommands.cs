﻿namespace app.web.core
{
  public interface IFindCommands
  {
    IProcessOneRequest get_command_that_can_process(IContainRequestInformation request);
  }
}