using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsLogger
    {
        private static string SourceName = "DVLD";

        static clsLogger()
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
        }

        private static string FormatLogMessage(Exception ex)
        {
            string Message =
                $"Time: {DateTime.Now}\n" +
                $"Message: {ex.Message}\n" +
                $"Stack Trace: {ex.StackTrace}\n" +
                $"Source: {ex.Source}\n";

            return Message;
        }

        public static void LogTheException(Exception ex, EventLogEntryType EntryType = EventLogEntryType.Error)
        {
            EventLog.WriteEntry(SourceName, FormatLogMessage(ex), EntryType);
        }
    }
}
