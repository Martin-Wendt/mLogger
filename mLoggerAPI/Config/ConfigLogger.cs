using mLoggerAPI.Enums;

namespace mLoggerAPI.Config
{
    public class ConfigLogger
    {
        public LogLevel MinimumLogLevel { get; }
        public LogFormat Format { get; }
        public LogOutput Output { get; }
        public string SubFolder { get; } 

        public ConfigLogger(LogLevel minimumLogLevel, LogFormat format, LogOutput output, string subFolder)
        {
            MinimumLogLevel = minimumLogLevel;
            Format = format;
            Output = output;
            SubFolder = subFolder;
        }
    }
}
