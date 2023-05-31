using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Controllers
{
    public class ApproveLoan : IApproveLoan
    {
        private ICalculateCharges _calculateCharges;
        private IPrinter _printer;
        private IAccountServerInterface _accountServerInterface;
        private IDisplay _display;
        private double _amount;

        public ApproveLoan(ICalculateCharges calculateCharges, IPrinter printer,
                           IAccountServerInterface accountServerInterface, IDisplay display)
        {
            _calculateCharges = calculateCharges;
            _printer = printer;
            _accountServerInterface = accountServerInterface;
            _display = display;
        }
        public bool Apply(double amount, int duration, double income, double expense)
        {
            _amount = amount;
            var charge = _calculateCharges.CalculateCharge(amount, duration);

            if (charge > 10)
            {
                _display.ShowInterestToBig(charge);
                return false;
            }

            _printer.PrintLoanDocument(amount, duration, charge);
            _display.ShowLoanApproved(charge);
            return true;
        }

        public bool RealiseLoan(int accountNumber)
        {
           return _accountServerInterface.BookForAmount(_amount, accountNumber);
        }
    }
}
