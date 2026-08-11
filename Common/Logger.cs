using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logger
    {

        public static void LogMessage(string message, EventLogEntryType ErrorType)
        {
            //Bu uygulama adı. Yani bu log DVLD'den geldiğini belirlemek için 
            string sourceName = "DVLD";




            //Bu kontrl ile, DVLD'de daha önceden event viewer'a eklenmilş mi kontrol ederiz. 
            //Eğer yoksa oluştururuz. Varsa onu kullanırız.
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            //Info
            EventLog.WriteEntry(sourceName, message, ErrorType);


        }
    }
}
