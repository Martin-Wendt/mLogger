// See https://aka.ms/new-console-template for more information

using mLogger.LogEvent;

namespace mLogger.Logger
{
    public interface IMLogger
    {
        void Log(IMLogEvent mLogEvent);
    }
}