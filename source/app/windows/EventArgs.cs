using System;

namespace app.windows
{
  public delegate void Event<EventData>(object sender, EventArgs<EventData> e);

  public class EventArgs<EventData> : EventArgs
  {
    public EventData data { get; private set; }

    public EventArgs(EventData data)
    {
      this.data = data;
    }
  }
}
