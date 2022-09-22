using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.System
{
    public class EntryNotification : IEntryNotification
    {
        public void NotifyEntryDenied(int id)
        {
            Console.WriteLine($"Entry Denied for {id}!");
        }
    }
}
