// See https://aka.ms/new-console-template for more information

using mLoggerAPI.LogEvent;

namespace mLoggerAPI.Logger
{
    public interface IMLogger
    {
        /// <summary>
        /// Log event
        /// </summary>
        /// <param name="mLogEvent">Log event To log</param>
        void Log(MLogEvent mLogEvent);
    }
}