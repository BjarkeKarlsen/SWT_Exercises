using ClassLibrary.Interfaces;
using System.ComponentModel;

namespace ClassLibrary.Boundry;
public class TimerModul : ITimerModul
{
    public event EventHandler<TimeOutEventArgs>? TimeOutEvent;
    public void Start(int time) 
    {
        Thread.Sleep(time);
        OnTimeOut(new TimeOutEventArgs { TimeEvent = time });
    }

    protected virtual void OnTimeOut(TimeOutEventArgs e) {
        TimeOutEvent?.Invoke(this, e);
    }
}

