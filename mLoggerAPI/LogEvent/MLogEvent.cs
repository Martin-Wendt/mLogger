// See https://aka.ms/new-console-template for more information


using mLoggerAPI.Enums;

namespace mLoggerAPI.LogEvent
{
    public class MLogEvent : IMLogEvent
    {
        public DateTimeOffset Timestamp { get; }
        public LogLevel LogLevel { get; set; }
        public string? Message { get; set; }
        public MLogEvent(string message, LogLevel level)
        {
            LogLevel = level;
            Message = message;
            Timestamp = DateTimeOffset.Now;
        }
        public MLogEvent()
        {

        }
        public MLogEvent(Exception exception, LogLevel level)
        {
            LogLevel = level;
            Message = exception.Message + exception.StackTrace + " [ inner:" + exception.InnerException + "]";
        }

        public override string ToString()
        {
            return $"{Timestamp} - {LogLevel} - {Message}";
        }
    }
}