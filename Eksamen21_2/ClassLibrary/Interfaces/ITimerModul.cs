namespace ClassLibrary.Interfaces;

public class TimeOutEventArgs : EventArgs {
    public int TimeEvent  { get; set; }
}

public interface ITimerModul
{
    public void Start(int time);

    event EventHandler<TimeOutEventArgs> TimeOutEvent;
}
