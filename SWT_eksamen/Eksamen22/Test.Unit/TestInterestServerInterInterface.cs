using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;
using NUnit.Framework;

namespace Test.Unit
{
    public class UnitTestExample
    {
        private IInterestServerInterface _uut;
        private InterestServerEventArgs _interestServerEventArgs;

        [SetUp]
        public void Setup() {
            _uut = new InterestServerInterface();

            _uut.LoanInterestEvent += (o, args) => {
                _interestServerEventArgs = args;
            };
        }

        [Test]
        public void NewInterest_LoanInterest_EventFired() {
            var interest = 32;
            _uut.NewInterest(interest);

            Assert.IsNotNull(_interestServerEventArgs);
        }
    

    }
}