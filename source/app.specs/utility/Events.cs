using System;
using System.Reflection;

namespace app.specs.utility
{
  public class Events
  {
    public static void raise_event(object sender, string event_name)
    {
      raise_event(sender, event_name,EventArgs.Empty);
    }

    public static void raise_event(object sender, string event_name, EventArgs args)
    {
      var event_method = sender.GetType()
                               .GetMethod(string.Format("On{0}", event_name),
                                          BindingFlags.NonPublic | BindingFlags.Instance);
      event_method.Invoke(sender, new object[] {args});
    }
  }
}