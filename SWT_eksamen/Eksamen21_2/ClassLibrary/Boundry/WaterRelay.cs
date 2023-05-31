using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry;
public class WaterRelay : IWaterRelay
{
    enum State {
        On, Off
    };

    private State _state;
    public WaterRelay() {
        _state = State.Off;
    }

    public void TurnOn() {
        _state = State.On;
    }

    public void TurnOff() {
        _state = State.Off;
    }

}