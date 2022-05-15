// See https://aka.ms/new-console-template for more information
using mLogger.Config;
using mLogger.LogEvent;
using System.Text.Json;

namespace mLogger.Outputs
{
    /// <summary>
    /// Outputter
    /// 
    /// singleton
    /// </summary>
    public sealed class LogToJson : ILogOutputHandler
    {
        private static LogToJson? _instance = null;
        private static readonly object _lock = new();

        private readonly IMLoggerConfig _config;
        private ILogOutputHandler? _successor;
        private readonly IWriteToOutput _writeToFile;
        private LogToJson(IMLoggerConfig config, IWriteToOutput writeToFile)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _writeToFile = writeToFile ?? throw new ArgumentNullException(nameof(writeToFile));
        }

        public static LogToJson GetInstance(IMLoggerConfig config, IWriteToOutput writeToFile)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogToJson(config, writeToFile);
                    }
                }
            }

            return _instance;
        }

        public void Write(IMLogEvent mLogEvent)
        {
            if (_config.LogToJSON)
            {
                var json = JsonSerializer.Serialize(mLogEvent);
                _writeToFile.WriteJsonToFile(json);
            }
            _successor?.Write(mLogEvent);
        }

        public ILogOutputHandler SetSuccessor(ILogOutputHandler successor)
        {
            _successor = successor;
            return successor;
        }
    }
}