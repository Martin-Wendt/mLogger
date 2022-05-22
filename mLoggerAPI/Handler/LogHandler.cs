using mLoggerAPI.Config;
using mLoggerAPI.LogEvent;
using mLoggerAPI.Output;

namespace mLoggerAPI
    .Outputs
{
    /// <summary>
    /// Outputter
    /// 
    /// singleton
    /// </summary>
    public sealed class LogHandler : ILogHandler
    {
        private ILogHandler? _successor;
        private readonly ConfigLogger _config;
        private readonly IWriteToOutput _writeToOutput;

        public LogHandler(ConfigLogger config, IWriteToOutput writeToOutput)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _writeToOutput = writeToOutput ?? throw new ArgumentNullException(nameof(writeToOutput));   
        }

        public void Write(MLogEvent mLogEvent)
        {
            if (mLogEvent.LogLevel >= _config.MinimumLogLevel)
            {
                _writeToOutput.Write(mLogEvent);                
            }
            _successor?.Write(mLogEvent);
        }

        public ILogHandler SetSuccessor(ILogHandler successor)
        {
            _successor = successor;
            return successor;
        }
    }
}