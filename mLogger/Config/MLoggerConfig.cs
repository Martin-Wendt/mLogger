// See https://aka.ms/new-console-template for more information
using mLogger.Enum;

namespace mLogger.Config
{
    public class MLoggerConfig : IMLoggerConfig
    {
        public LogLevel Loglevel { get; }
        public string OutputPath { get; }
        public bool LogToConsole { get; }
        public bool LogToJSON { get; }
        public bool LogToXML { get; }
        public MLoggerConfig(LogLevel loglevel = LogLevel.Warning, string path = @"c:\logs", bool logToConsole = false, bool logToJSON = false, bool logToXML = false)
        {
            Loglevel = loglevel;
            OutputPath = path;
            LogToConsole = logToConsole;
            LogToJSON = logToJSON;
            LogToXML = logToXML;
        }
    }
}