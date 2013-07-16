using System.Windows.Forms;
using app.core;

namespace app.windows
{
    public class ButtonSwitcher : IRun
    {
        private Button trigger;
        private Button[] targets;

        public ButtonSwitcher(Button trigger, Button[] targets)
        {
            this.trigger = trigger;
            this.targets = targets;
        }

        public void run()
        {
            foreach (var target in targets)
            {
                target.Enabled = !target.Enabled;
            }

            trigger.Text = trigger.Text == "Enable" ? "Disable" : "Enable";
        }
    }
}