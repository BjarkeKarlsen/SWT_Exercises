using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Boundry
{
    public class Touchscreen : ITouchscreen
    {
        public void ShowHumidity(int Measure) 
        {
            Console.WriteLine($"Measure {Measure}");
        }
        public void ShowAlarm(STMState state) 
        {
            Console.WriteLine($"Alarm {state}!!!");
        }
        public void DeleteAlarm() 
        {
        }
    }
}
