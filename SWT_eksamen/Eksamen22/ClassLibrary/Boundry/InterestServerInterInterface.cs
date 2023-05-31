using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Boundry
{
    public class InterestServerInterface : IInterestServerInterface
    {
        public event EventHandler<InterestServerEventArgs>? LoanInterestEvent;

        public void NewInterest(double interest) {
            OnNewInterest(new InterestServerEventArgs { LoanInterest = interest });
        }
        protected virtual void OnNewInterest(InterestServerEventArgs e) {
            LoanInterestEvent?.Invoke(this, e);
        }

    }
}
