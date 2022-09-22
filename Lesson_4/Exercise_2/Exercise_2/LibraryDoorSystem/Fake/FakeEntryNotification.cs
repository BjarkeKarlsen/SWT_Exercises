using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.Fake
{
    public class FakeEntryNotification : IEntryNotification
    {
        public void NotifyEntryDenied(int id)
        {
            Console.WriteLine($"Entry Denied for {id}!");
        }

    }
}
