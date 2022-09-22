using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDoorSystem.Interface;

namespace LibraryDoorSystem.System
{
    public class Alarm : IAlarm
    {
        public Alarm()
        {
        }

        public void RaiseAlarm()
        {
            Console.WriteLine("Alarm is on!");
        }
    }
}