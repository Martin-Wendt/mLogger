// See https://aka.ms/new-console-template for more information

using mLogger.Enum;

namespace mLogger.LogEvent
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

    }
}