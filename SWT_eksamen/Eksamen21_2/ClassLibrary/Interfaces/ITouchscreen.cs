
namespace ClassLibrary.Interfaces
{
    public interface ITouchscreen
    {
        public void ShowHumidity(int Measure);
        public void ShowAlarm(STMState state);
        public void DeleteAlarm();
    }
}
