using System.Windows.Forms;
using app.core;

namespace app.window
{
  public class ButtonTriggeredAction
  {
    IRun action;
    Button button;

    public ButtonTriggeredAction(IRun action, Button button)
    {
      this.action = action;
      this.button = button;

      hookup_event_handlers();
    }

    void hookup_event_handlers()
    {
      button.Click += delegate
      {
        action.run();
      };
    }
  }
}