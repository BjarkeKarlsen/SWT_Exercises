﻿using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.Fake
{
    public class FakeUserValidation : IUserValidation
    {
        private readonly int _id = 5;

        public bool ValidateEntryRequest(int id)
        {
            return (id == _id);
        }
    }
}