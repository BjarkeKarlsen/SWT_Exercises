using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DoorSystem
{
    [TestFixture]
    public class DoorUnitTest
    {
        // addd fields
        private DoorControl uut;

        [SetUp]
        public void Setup()
        {
            var sub = Substitute.For<IDoorControl>();
            uut = new DoorControl();
        }

    }
}
