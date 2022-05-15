// See https://aka.ms/new-console-template for more information
using mLogger.Enum;

namespace mLogger.Config
{
    public interface IMLoggerConfig
    {
        LogLevel Loglevel { get; }
        bool LogToConsole { get; }
        bool LogToJSON { get; }
        bool LogToXML { get; }
        string OutputPath { get; }
    }
}