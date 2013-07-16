 using System.Windows.Forms;
 using Machine.Specifications;
 using app.core;
 using app.specs.utility;
 using app.window;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ButtonTriggeredAction))]  
  public class ButtonTriggeredActionSpecs
  {
    public abstract class concern : Observes<ButtonTriggeredAction>
    {
        
    }

   
    public class when_the_button_for_the_trigger_is_clicked  : concern
    {
      Establish c = () =>
      {
        button = new Button();
        action = depends.on<IRun>();
        depends.on(button);
      };

      Because b = () =>
        Events.raise_event(button, "Click");


      It should_run_its_associated_action = () =>
        action.received(x => x.run());

      static IRun action;
      static Button button;
    }
  }
}
