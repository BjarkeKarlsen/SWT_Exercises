﻿using LibraryDoorSystem.Interface;
using LibraryDoorSystem.System;

namespace LibraryDoorSystem.Fake
{

    public class FakeDoor : IDoor
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