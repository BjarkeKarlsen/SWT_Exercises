using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IDisplay
    {
        public void UpdateLoanInterest(double loanInterest);
        public void ShowInterestToBig(double loanInterest);
        public void ShowLoanApproved (double loanInterest);
    }
}
