using System.Linq;
using System.Windows.Forms;
using Machine.Specifications;
using app.core;
using app.windows;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ButtonSwitcher))]
    public class ButtonSwitcherSpecs
    {
        public abstract class concern : Observes<IRun,
                                      ButtonSwitcher>
        {

        }

        public class when_click_the_trigger_button : concern
        {
            Establish c = () =>
                              {
                                  triggerButton = new Button();
                                  targetButtons = new[] {new Button(), new Button()};
                                  depends.on(triggerButton);
                                  depends.on(targetButtons);
                              };

            Because b = () =>
              sut.run();

            It should_disable_all_target_buttons = () =>
                                                           targetButtons.Any(t => t.Enabled).ShouldEqual(false);

            private It should_display_enable_text = () =>
                                                     triggerButton.Text.ShouldEqual("Enable");

            static Button triggerButton;
            static Button[] targetButtons;
        }

        public class when_click_the_trigger_button_the_second_time : concern
        {
            Establish c = () =>
            {
                triggerButton = new Button();
                targetButtons = new[] { new Button(), new Button() };
                depends.on(triggerButton);
                depends.on(targetButtons);
            };

            private Because b = () =>
                                    {
                                        sut.run();
                                        sut.run();
                                    };
              

            It should_enable_all_target_buttons = () =>
                                                           targetButtons.All(t => t.Enabled).ShouldEqual(true);

            private It should_display_disable_text = () =>
                                                     triggerButton.Text.ShouldEqual("Disable");

            static Button triggerButton;
            static Button[] targetButtons;
        }

    }
}
