﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IAccountServerInterface
    {
        public bool BookForAmount(double amount, int accountNumber);
    }
}
