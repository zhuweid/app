using System;

namespace app.core
{
  public interface IRun
  {
    void run();
  }

  public interface ICanBeEnabledAndDisabled
  {
    void enable();
    void disable();
  }

  public interface INotifyOfEnabledStateChange
  {
    event EnableStateChanged enable_state_changed;
  }

  public class EventArgs<EventData> : EventArgs
  {
    public EventData data { get; private set; }

    public EventArgs(EventData data)
    {
      this.data = data;
    }
  }

  public delegate void EnableStateChanged(object sender, EventArgs<bool> e);

  public class StateAwareAction : ICanBeEnabledAndDisabled, IRun, INotifyOfEnabledStateChange
  {
    IRun action;

    public event EnableStateChanged enable_state_changed = delegate
    {
    };

    public StateAwareAction(IRun action)
    {
      this.action = action;
    }

    void on_enable_state_changed(bool enabled)
    {
      this.enable_state_changed(this, new EventArgs<bool>(enabled));
    }

    public void enable()
    {
      on_enable_state_changed(true);
    }

    public void disable()
    {
      on_enable_state_changed(false);
    }

    public void run()
    {
      action.run();
    }
  }
}