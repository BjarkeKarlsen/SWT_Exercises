using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IApproveLoan
    {
        public bool Apply(double amount, int duration, double income, double expense);
        public bool RealiseLoan(int accountNumber);
    }
}
