using System;
using app.core;

namespace app.winui
{
  public class AnonymousAction : IRun
  {
    Action action;

    public AnonymousAction(Action action)
    {
      this.action = action;
    }

    public void run()
    {
      action();
    }
  }
}