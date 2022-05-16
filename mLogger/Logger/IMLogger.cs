// See https://aka.ms/new-console-template for more information

using mLogger.LogEvent;

namespace mLogger.Logger
{
    public interface IMLogger
    {
        /// <summary>
        /// Log event
        /// </summary>
        /// <param name="mLogEvent">Log event To log</param>
        void Log(IMLogEvent mLogEvent);
    }
}