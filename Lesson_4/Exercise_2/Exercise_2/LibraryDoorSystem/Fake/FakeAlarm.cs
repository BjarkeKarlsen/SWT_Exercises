namespace LibraryDoorSystem
{
    public class FakeAlarm
    {

        private int _id;


        public void RequestEntry(int id)
        {
            _id = id;
        }

        public void DoorOpened()
        {

        }

        public void DoorClosed()
        {

        }
    }
}