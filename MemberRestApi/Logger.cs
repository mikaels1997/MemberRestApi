using System;
using System.Diagnostics;
using System.IO;

namespace MemberRestApi
{
    /// <summary>
    /// Logs information to .log files
    /// </summary>
    public class Logger
    {
        public const string logFilePath = ".//DatabaseLogs//";
        public Logger(string fileName)
        {
            string path = logFilePath + fileName;
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write);
            TextWriterTraceListener listener = new TextWriterTraceListener(stream);
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;
        }

        /// <summary>
        /// Logs the provided message and current date
        /// </summary>
        public static void logInfo(string msg)
        {
            Trace.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " " + msg);
        }
    }

}