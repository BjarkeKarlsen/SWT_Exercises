using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.System
{
    public class Door : IDoor
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
