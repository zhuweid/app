using System;

namespace app.core
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