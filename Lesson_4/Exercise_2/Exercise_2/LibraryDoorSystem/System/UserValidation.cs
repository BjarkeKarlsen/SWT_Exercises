using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.System
{
    public class UserValidation : IUserValidation
    {
        private readonly int _id = 5;

        public bool ValidateEntryRequest(int id)
        {
            return (id == _id);
        }
    }
}

