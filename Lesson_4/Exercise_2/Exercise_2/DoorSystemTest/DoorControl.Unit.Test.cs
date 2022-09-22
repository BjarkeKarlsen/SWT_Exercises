using LibraryDoorSystem.Fake;
using LibraryDoorSystem.System;
using NSubstitute;

namespace DoorSystemTest
{
    public class Tests
    {
        private DoorControl uut;

        [SetUp]
        public void Setup()
        {
            //var sub = Substitute.For<IDoorControl>();
            uut = new DoorControl(new FakeDoor(), new FakeAlarm(), new FakeEntryNotification(), new UserValidation());
        }


        [Test]
        //
        public void Test1()
        {
            Assert.Pass();
        }


    }
}