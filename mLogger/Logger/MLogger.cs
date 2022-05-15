using mLogger.Config;
using mLogger.LogEvent;
using mLogger.Outputs;

namespace mLogger.Logger
{
    public class MLogger : IMLogger
    {
        private static MLogger? _instance = null;
        private static readonly object _lock = new();

        private readonly IMLoggerConfig _config;
        private readonly ILogOutputHandler _outputHandlerChain;

        private MLogger(IMLoggerConfig config, ILogOutputHandler outputHandlerChain)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _outputHandlerChain = outputHandlerChain ?? throw new ArgumentNullException(nameof(outputHandlerChain));
        }

        public static MLogger GetInstance(IMLoggerConfig config, ILogOutputHandler outputHandler)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MLogger(config, outputHandler);
                    }
                }

            }

            return _instance;
        }

        public void Log(IMLogEvent mLogEvent)
        {
            if (mLogEvent.LogLevel >= _config.Loglevel && !string.IsNullOrWhiteSpace(mLogEvent.Message))
            {
                _outputHandlerChain.Write(mLogEvent);
            }
        }

        public static void Reset()
        {
            _instance = null;
        }
    }
}