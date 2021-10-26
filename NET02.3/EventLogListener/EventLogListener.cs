using NET02._3;
using System;
using System.Diagnostics;

namespace EventLogListener
{
    public class EventLogListener : IListener
    {
        public string Path { get; set; }
        public Level Level { get; set; }

        public void Write(string message, Level level)
        {
            if (level <= Level)
            {
                if (!EventLog.SourceExists("MyEventLog"))
                {
                    EventLog.CreateEventSource("Logger", "MyEventLog");
                }
                EventLog myLog = new EventLog("MyEventLog");
                myLog.Source = "Logger";
                if(level == Level.DEBUG || level == Level.INFO || level == Level.TRACE)
                    myLog.WriteEntry(DateTime.Now + "|" + level.ToString() + "|" + message,EventLogEntryType.Information,1);
                else if(level == Level.WARN)
                    myLog.WriteEntry(DateTime.Now + "|" + level.ToString() + "|" + message, EventLogEntryType.Warning,2);
                else if(level == Level.ERROR || level == Level.FATAL)
                    myLog.WriteEntry(DateTime.Now + "|" + level.ToString() + "|" + message, EventLogEntryType.Error, 3);
            }
        }
    }
}
