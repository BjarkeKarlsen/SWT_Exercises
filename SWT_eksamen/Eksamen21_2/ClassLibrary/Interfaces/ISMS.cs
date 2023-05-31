using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ISMS
    {
        public void SendAlarmOccured(STMState Alarm);
        public void DeleteAlarmOccured(STMState Alarm);
    }
}
