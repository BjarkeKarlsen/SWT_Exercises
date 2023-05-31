using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IPrinter
    {
        public void PrintLoanDocument(double amount, int duration, double interest);
    }
}
