using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;
using ClassLibrary.Mocks;
using NSubstitute;
using NUnit.Framework;

namespace Test.Unit
{
    public class UnitTestApproveLoan
    {
        private IApproveLoan _uut;
        private ICalculateCharges _calculateCharges;
        private IPrinter _printer;
        private IAccountServerInterface _accountServerInterface;
        private IDisplay _display;

        [SetUp]
        public void Setup() {
            _calculateCharges = Substitute.For<ICalculateCharges>();
            _printer = Substitute.For<IPrinter>();
            _accountServerInterface = Substitute.For<IAccountServerInterface>();
            _display = Substitute.For<IDisplay>();

            _uut = new ApproveLoan(_calculateCharges, _printer, _accountServerInterface, _display);
        }

        [Test]
        public void Apply_ReturnsTrue() {
            double loanInterest = 100000;
            int duration = 120;
            // This is a substitude, therefore interest is never set
            double interest = 0;

            bool isApplied = _uut.Apply(loanInterest, duration, 24000, 14000);
            _display.Received(1).ShowLoanApproved(interest);
            _printer.Received(1).PrintLoanDocument(loanInterest, duration, interest);

           Assert.IsTrue(isApplied);
        }

        [Test]
        public void Apply_ReturnsFalse() {
            //Arrange
            _calculateCharges = new MockCalulateCharges();
            _uut = new ApproveLoan(_calculateCharges, _printer, _accountServerInterface, _display);
            double loanInterest = 100000;
            int duration = 120;

            //Act
            // Change calculate to return the amount 
            _calculateCharges.CalculateCharge(11, 11);
            bool isApplied = _uut.Apply(loanInterest, duration, 24000, 14000);

            //Assert
            // This is a substitude, therefore interest is never set
            _display.Received(1).ShowInterestToBig(loanInterest);
            _display.Received(0).ShowLoanApproved(loanInterest);
            _printer.Received(0).PrintLoanDocument(loanInterest, duration, loanInterest);

            Assert.IsFalse(isApplied);
        }

        [Test]
        public void RealiedLoan_ReturnsFalse() {
            int accountNumber = 12345678;

            var isReceived = _uut.RealiseLoan(accountNumber);
            _accountServerInterface.Received(1).BookForAmount(0, accountNumber);

            Assert.IsFalse(isReceived);
        }

        [Test]
        public void RealiedLoan_ReturnsTrue() {
            //Arrange
            _accountServerInterface = new MockAccountServerInterface();
            _uut = new ApproveLoan(_calculateCharges, _printer, _accountServerInterface, _display);
            int accountNumber = 12345678;
            //Act
            var isReceived = _uut.RealiseLoan(accountNumber);
            //Assert
            Assert.IsTrue(isReceived);
        }
    }
}