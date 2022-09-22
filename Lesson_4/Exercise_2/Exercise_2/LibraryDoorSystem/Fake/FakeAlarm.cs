using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.Fake
{
    public class FakeAlarm : IAlarm
    {
        public FakeAlarm()
        {
        }

        public void RaiseAlarm()
        {
            Console.WriteLine("Alarm is on!");
        }
    }
}