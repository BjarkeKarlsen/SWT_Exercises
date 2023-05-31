using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ICalculateCharges
    {
        public double ActualLoan { get; }
        public double CalculateCharge(double amount, int duration);
        public void HandleNewLoan(object sender, InterestServerEventArgs loanInterest);

    }
}
