﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDoorSystem.Interface
{
    public interface IEntryNotification
    {
        public void NotifyEntryDenied(int id);
    }
}
