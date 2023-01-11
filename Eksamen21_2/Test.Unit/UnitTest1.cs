using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;
using NSubstitute;

namespace Test.Unit
{
    public class UnitTestExample
    {
        ControlHumidity _uut;
        IHumidityMeter _humidity;
        ISMS _smsService;
        ITimerModul _timerModul;
        ITouchscreen _screen;
        IWaterRelay _waterRelay;

        [SetUp]
        public void Setup()
        {  
            _humidity = new HumidityMeter();
            _timerModul = Substitute.For<ITimerModul>();
            _smsService = Substitute.For<ISMS>();
            _screen = Substitute.For<ITouchscreen>();
            _waterRelay = Substitute.For<IWaterRelay>();
            _uut = new ControlHumidity(_humidity, 
                                            _smsService, _screen,
                                            _waterRelay, _timerModul);
        }

        [TestCase(56)]
        [TestCase(70)]
        [TestCase(85)]
        public void CaseNormal(int humdity)
        {
            _humidity.SetHumidity(humdity);
            _timerModul.TimeOutEvent += Raise.EventWith(new TimeOutEventArgs { TimeEvent = 1 });
           
            var result = _humidity.GetHumidity();
            _screen.Received(1).ShowHumidity(humdity);
            Assert.That(humdity, Is.EqualTo(result));
        }


        [TestCase(86)]
        [TestCase(99)]
        [TestCase(100)]
        public void CaseWet(int humdity) {
            _humidity.SetHumidity(humdity);
            _timerModul.TimeOutEvent += Raise.EventWith(new TimeOutEventArgs { TimeEvent = 1 });
            // Wet State from here on
            var result = _humidity.GetHumidity();
            _screen.Received(1).ShowHumidity(humdity);
            Assert.That(humdity, Is.EqualTo(result));

            _screen.Received(1).ShowHumidity(humdity);
            _screen.Received(1).ShowAlarm(ClassLibrary.STMState.WetAlarm);

            // Normal State from here on
            _humidity.SetHumidity(67);
            _timerModul.TimeOutEvent += Raise.EventWith(new TimeOutEventArgs { TimeEvent = 1 });
            _waterRelay.DidNotReceive().TurnOn();

        }

    }
}