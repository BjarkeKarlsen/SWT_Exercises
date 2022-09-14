using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Redesign
{
    public class TempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

    }
}
