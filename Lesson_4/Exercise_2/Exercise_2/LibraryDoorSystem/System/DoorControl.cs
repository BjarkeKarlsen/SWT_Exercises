using System;
using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.System
{
    public class DoorControl
    {
        private IDoor _door;
        private IAlarm _alarm;
        private IEntryNotification _entryNotification;
        private IUserValidation _userValidation;

        private bool _currentState;
        private const bool Close = false;
        private const bool Open = true;


        public DoorControl(IDoor door, IAlarm alarm, IEntryNotification entryNotification, IUserValidation userValidation)
        {
            _door = door;
            _alarm = alarm;
            _entryNotification = entryNotification;
            _userValidation = userValidation;
        }


        public void RequestEntry(int id)
        {

            if (!_userValidation.ValidateEntryRequest(id))
                _entryNotification.NotifyEntryDenied(id);
            else if (!_userValidation.ValidateEntryRequest(id) && _currentState == Open)
                _alarm.RaiseAlarm();

        }

        public void DoorOpened()
        {
            if (_currentState == Close)
            {
                _currentState = _door.Open();
            }
        }

        public void DoorClosed()
        {
            if (_currentState == Open)
            {
                _currentState = _door.Close();
            }

        }



    }
}