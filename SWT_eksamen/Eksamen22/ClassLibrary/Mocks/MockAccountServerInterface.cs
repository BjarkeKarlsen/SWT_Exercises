using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Mocks
{
    public class MockAccountServerInterface : IAccountServerInterface
    {
        public bool BookForAmount(double amount, int accountNumber) => true;
    }
}
