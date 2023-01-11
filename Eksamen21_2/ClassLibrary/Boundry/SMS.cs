using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Boundry
{
    public class SMS : ISMS
    {
        public void SendAlarmOccured(STMState Alarm) 
        {
            Console.WriteLine(Alarm);
        }
        public void DeleteAlarmOccured(STMState Alarm)
        {
            Console.WriteLine(Alarm);
        }
    }
}
