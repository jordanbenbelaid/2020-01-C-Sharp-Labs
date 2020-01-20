using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_05_log_to_event_viewer
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog.WriteEntry("Application","Youre system is about to expire - Run for the hills",EventLogEntryType.Error,5000,1234);
        }
    }
}
