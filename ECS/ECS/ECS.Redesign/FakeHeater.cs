using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Redesign
{
    public class FakeHeater : IHeater
    {
        public bool isHeating { get; protected set; }
        public void TurnOn()
        {
            isHeating = true;
        }

        public void TurnOff()
        {
            isHeating = false;
        }
    }
}
