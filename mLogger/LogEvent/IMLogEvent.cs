// See https://aka.ms/new-console-template for more information

using mLogger.Enum;

namespace mLogger.LogEvent
{
    public interface IMLogEvent
    {
        LogLevel LogLevel { get; }
        string? Message { get; }

    }
}