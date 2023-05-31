using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Boundry
{
    public class CalculateCharges : ICalculateCharges {

        private double _actualLoan;
        public double ActualLoan { get { return _actualLoan; } private set { _actualLoan = value; } }
        private IInterestServerInterface _interestServerInterface;
        private IDisplay _display;
        public CalculateCharges(IInterestServerInterface interestServerInterface, IDisplay display) {
             ActualLoan = 0;
            // It is the CalulateCharges that handle event from InterestServerInterface
            _interestServerInterface = interestServerInterface;
            _interestServerInterface.LoanInterestEvent += HandleNewLoan;
            _display = display;
        }

        public double CalculateCharge(double amount, int duration) {
            double charge = double.MaxValue;

            if (duration < 1 || duration > 120) {
                return charge;
            }

            if (ActualLoan == 0) {
                charge = amount / duration;

            }
            else {
                charge = amount * ActualLoan / (1 - Math.Pow((1 + ActualLoan), - duration));
            }

            return charge;
        }

        public void HandleNewLoan(object sender, InterestServerEventArgs e) {
            ActualLoan = e.LoanInterest;
            _display.UpdateLoanInterest(ActualLoan);
        }
    }
}
