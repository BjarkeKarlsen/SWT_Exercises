using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Test.Unit
{
    public class UnitTestCalulateCharges
    {
        private ICalculateCharges _uut;
        private IInterestServerInterface _interestServerInterface;
        private IDisplay _display;

        [SetUp]
        public void Setup() {
            _display = Substitute.For<IDisplay>();
            _interestServerInterface = Substitute.For<IInterestServerInterface>();
            _uut = new CalculateCharges(_interestServerInterface, _display);
        }



        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(23)]
        public void HandleNewLoan_EventFired_ActualLoanCorrectValues(double loanInterest) {
            _interestServerInterface.LoanInterestEvent += Raise.
                EventWith(new InterestServerEventArgs { LoanInterest = loanInterest });

            _display.Received(1).UpdateLoanInterest(loanInterest);
            Assert.That(_uut.ActualLoan, Is.EqualTo(loanInterest));
        }


        [TestCase(2341.78, 1)]
        [TestCase(2323412, 2)]
        [TestCase(24.67, 60)]
        [TestCase(-231, 119)]
        [TestCase(2341, 120)]
        public void CalculateCharges_ActualLoanIsNull_ChargeCorrectValue(double loan, int duartion ) {
            var interest = _uut.CalculateCharge(loan, duartion);
            var charge = loan / duartion;

            Assert.That(interest, Is.EqualTo(charge));
        }

        [TestCase(2341.78, 0)]
        [TestCase(2323412, 121)]
        [TestCase(24.67, -5)]
        public void CalculateCharges_DurationOutOfIntervals_ChargeReturned(double loan, int duartion) {
            var interest = _uut.CalculateCharge(loan, duartion);

            Assert.That(interest, Is.EqualTo(double.MaxValue));
        }


        [TestCase(2341.78, 1, 0.01)]
        [TestCase(2323412, 2, -0.01)]
        [TestCase(24.67, 60, 1000)]
        [TestCase(-231, 119, -1000)]
        [TestCase(2341, 120, 20)]
        public void CalculateCharges_ActualLoanNotNull_ChargeCorrectValue(double loan, int duration, double loanInterest) {
            //Change the Loan interest to other than 0
            _interestServerInterface.LoanInterestEvent += Raise.EventWith(new InterestServerEventArgs { LoanInterest = loanInterest });
            var interest = _uut.CalculateCharge(loan, duration);
            //This part is white box
            var charge = loan * loanInterest / (1 - Math.Pow((1 + loanInterest), -duration));

            Assert.That(interest, Is.EqualTo(charge));
        }

    }
}