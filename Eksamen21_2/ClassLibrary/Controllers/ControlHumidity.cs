using ClassLibrary.Interfaces;
using System.ComponentModel;

namespace ClassLibrary.Controllers;

public class ControlHumidity 
{
    // properties og fields her        
    private STMState _state;
    IHumidityMeter _humidityMeter;
    ISMS _sms;
    ITouchscreen _touchscreen;
    IWaterRelay _waterRelay;
    ITimerModul _timerModul;
    private int _count;
    readonly private int _maximum = 85;
    readonly private int _minimum = 50;
    public int Measured { get; private set; }

    // constructor her (reset STM, osv.)
    public ControlHumidity(IHumidityMeter humidityMeter, ISMS sms, ITouchscreen touchscreen, IWaterRelay waterRelay, ITimerModul timerModul) {
        _humidityMeter = humidityMeter;
        _sms = sms;
        _timerModul = timerModul;
        _waterRelay = waterRelay;
        _touchscreen = touchscreen;
        _state = STMState.Idle;
        timerModul.TimeOutEvent += TimeOut;
        _timerModul = timerModul;
    }


    private void TimeOut(object sender, EventArgs e) {
        int measured;

        switch (_state) {
            case STMState.Idle:
                // Get measurement
                measured = _humidityMeter.GetHumidity();
                _touchscreen.ShowHumidity(measured);

                if (measured > _maximum) {
                    // Wet alarm
                    // Change state
                    _state = STMState.WetAlarm;
                    _touchscreen.ShowAlarm(_state);
                    _timerModul.Start(60);
                }
                // Måske flere - se STM
                else if (measured < _minimum && _count >= 10) {
                    // Dry
                    _state = STMState.DryAlarm;
                    _touchscreen.ShowAlarm(_state);
                    _timerModul.Start(60); 
                }
                else if (measured < _minimum && _count < 10) {
                    // Pumping
                    _state |= STMState.Pumping;

                    //Actoins
                    _waterRelay.TurnOn();
                    _timerModul.Start(15);
                    
                }
                else if (_minimum <= measured && measured <= _maximum) {
                    // Within limits, everything is OK
                    _count = 0;
                    _timerModul.Start(60);
                }
                else {
                }
            break;

            case STMState.Pumping:
            // Stop water again and go to idle
                _waterRelay.TurnOff();    
                _count++;
                _state = STMState.Idle;
                _timerModul.Start(60);
            break;

            case STMState.WetAlarm:
                // Get measurement
                measured = _humidityMeter.GetHumidity();
                _touchscreen.ShowHumidity(measured);
                if (measured >= _minimum) {
                    _touchscreen.DeleteAlarm();
                    _count = 0;
                    _state = STMState.Idle;
                    _timerModul.Start(60);
                }
                else {
                    // Still too wet
                    _timerModul.Start(60);
                }
            break;

            case STMState.DryAlarm:
                measured = _humidityMeter.GetHumidity();
                if (measured <= _maximum) { 
                    _touchscreen.DeleteAlarm();
                    _count = 0;
                    _state = STMState.Idle;
                    _timerModul.Start(60);
                }
                else {
                    // Still too dry
                    _timerModul.Start(60);
                }
            break;
                
        }
    }
}
