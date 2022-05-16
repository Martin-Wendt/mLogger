// See https://aka.ms/new-console-template for more information
using mLogger.Enum;

namespace mLogger.Config
{
    public interface IMLoggerConfig
    { 
        /// <summary>
        /// Log Level
        /// </summary>
        LogLevel Loglevel { get; }
        /// <summary>
        /// Log to Console if true
        /// </summary>
        bool LogToConsole { get; }
        /// <summary>
        /// Log to Json if true
        /// </summary>
        bool LogToJSON { get; }
        /// <summary>
        /// Log to XML is true
        /// </summary>
        bool LogToXML { get; }
        /// <summary>
        /// Log destination on harddrive
        /// </summary>
        string OutputPath { get; }
    }
}