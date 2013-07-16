using System;
using System.Reflection;

namespace app.specs.utility
{
  public class Events
  {
    public static void raise_event(object sender, string event_name)
    {
      var event_method = sender.GetType()
                               .GetMethod(string.Format("On{0}", event_name),
                                          BindingFlags.NonPublic | BindingFlags.Instance);
      event_method.Invoke(sender, new object[] {EventArgs.Empty});
    }
  }
}