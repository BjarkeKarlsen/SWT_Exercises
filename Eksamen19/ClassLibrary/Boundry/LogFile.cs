using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Boundry
{

    public class LogFile : ILogfile
    {
        private string _logFile = "logfile.txt"; // Navnet på systemets log-fil

        public void LogEntry(DateTime time, int temp) {
            using (var writer = File.AppendText(_logFile)) {
                writer.WriteLine(time + ": Temperatur: {0}. Varme tændt.", temp);
            }
        } 
    }
}
