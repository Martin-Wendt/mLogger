// See https://aka.ms/new-console-template for more information

using mLoggerAPI.Enums;

namespace mLoggerAPI.LogEvent
{
    public interface IMLogEvent
    {
        /// <summary>
        /// Level of Log
        /// </summary>
        LogLevel LogLevel { get; }
        /// <summary>
        /// Log message
        /// </summary>
        string? Message { get; }
        DateTimeOffset Timestamp { get; }

    }
}