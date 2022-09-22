namespace LibraryDoorSystem.System
{
    public class Door
    {
        private const bool CloseDoor = false;
        private const bool OpenDoor = true;

        public bool Open()
        {

            return OpenDoor;
        }

        public bool Close()
        {
            return CloseDoor;
        }
    }
}
