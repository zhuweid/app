using System.Windows.Forms;
using app.core;

namespace app.windows
{
  public class ClickTriggeredAction
  {
    IRun action;
    Control control;

    public ClickTriggeredAction(IRun action, Control control)
    {
      this.action = action;
      this.control = control;

      hookup_event_handlers();
    }

    void hookup_event_handlers()
    {
      control.Click += delegate
      {
        action.run();
      };
    }
  }
}