using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ILogfile
    {
        public void LogEntry(DateTime time, int temp);
    }
}
