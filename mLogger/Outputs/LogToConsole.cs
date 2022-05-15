using mLogger.Config;
using mLogger.LogEvent;

namespace mLogger.Outputs
{
    /// <summary>
    /// Outputter
    /// 
    /// singleton
    /// </summary>
    public sealed class LogToConsole : ILogOutputHandler
    {
        private static LogToConsole? _instance = null;
        private static readonly object _lock = new();

        private ILogOutputHandler? _successor;
        private readonly IMLoggerConfig _config;
        private readonly IWriteToOutput _writeToOutput;

        private LogToConsole(IMLoggerConfig config, IWriteToOutput writeToOutput)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _writeToOutput = writeToOutput ?? throw new ArgumentNullException(nameof(writeToOutput));

        }

        public static LogToConsole GetInstance(IMLoggerConfig config, IWriteToOutput writeToOutput)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogToConsole(config, writeToOutput);
                    }
                }
            }

            return _instance;
        }

        public void Write(IMLogEvent mLogEvent)
        {
            if (_config.LogToConsole)
            {
                _writeToOutput.WriteToConsole($"{mLogEvent.LogLevel} : {mLogEvent.Message}");
            }

            _successor?.Write(mLogEvent);
        }

        public ILogOutputHandler SetSuccessor(ILogOutputHandler successor)
        {
            _successor = successor;
            return successor;
        }

        public static void Reset()
        {
            _instance = null;
        }
    }
}