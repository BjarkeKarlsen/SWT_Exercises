using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public class InterestServerEventArgs : EventArgs
    {
        public double LoanInterest { get; set; }
    }
    public interface IInterestServerInterface
    {
        public void NewInterest(double interest);
        event EventHandler<InterestServerEventArgs> LoanInterestEvent;
    }
    
}
