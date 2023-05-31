using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Mocks
{
    public class MockCalulateCharges : ICalculateCharges
    {
        public double ActualLoan => throw new NotImplementedException();

        public double CalculateCharge(double amount, int duration) {
            return amount;
        }

        public void HandleNewLoan(object sender, InterestServerEventArgs loanInterest) {
            throw new NotImplementedException();
        }

    }
}
