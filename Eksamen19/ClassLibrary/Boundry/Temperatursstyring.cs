using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry;
    public class Temperatursstyring : ITemperaturstyring
    {
        class TemperaturStyring
        {

            private ILogfile _logfile;
            private IRelae _varmRelae;
            
            public TemperaturStyring(IRelae varmRelae, ILogfile logfile) {
                _varmRelae = varmRelae;
                _logfile = logfile;
            }


        // Tilstandsmaskinens tilstande
        private enum State
            {
                Slukket,
                Tændt
            }

            private State _state;

            public bool IsHeatOn() {
            return _state == State.Tændt;
;
        }

        public void TemperatureChanged(int temp) {
                switch (_state) {
                    // Principiel implementation ifølge tilstandsmaskinediagrammet
                    // For tilstand Slukket, når der kommer en ny temperatur
                    case State.Slukket:
                    if (temp < 0) {
                        _state = State.Tændt;

                        _varmRelae.TurnOn();
                        _logfile.LogEntry(DateTime.Now, temp);

                    }
                    break;

                    case State.Tændt:
                    if (temp <= 2) {
                        _state = State.Slukket;

                        _varmRelae.TurnOff();
                        _logfile.LogEntry(DateTime.Now, temp);
                    }

                break;
                }
            }


        }

    }
