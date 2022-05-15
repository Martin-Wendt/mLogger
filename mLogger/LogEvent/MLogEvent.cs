// See https://aka.ms/new-console-template for more information
using mLogger.Enum;

namespace mLogger.LogEvent
{
    public class MLogEvent : IMLogEvent
    {
        public string? Message { get; set; }
        public LogLevel LogLevel { get; set; }
        public MLogEvent(string message, LogLevel level)
        {
            LogLevel = level;
            Message = message;
        }
        public MLogEvent()
        {

        }
        public MLogEvent(Exception exception, LogLevel level)
        {
            LogLevel = level;
            Message = exception.Message + exception.StackTrace + " [ inner:" + exception.InnerException + "]";
        }
    }
}