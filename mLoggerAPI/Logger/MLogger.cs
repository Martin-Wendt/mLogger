using mLoggerAPI.LogEvent;
using mLoggerAPI.Outputs;

namespace mLoggerAPI.Logger
{
    public class MLogger : IMLogger
    {

        private readonly ILogHandler _outputHandlerChain;

        public MLogger(ILogHandler outputHandlerChain)
        {
            _outputHandlerChain = outputHandlerChain ?? throw new ArgumentNullException(nameof(outputHandlerChain));
        }

        public void Log(MLogEvent mLogEvent)
        {
            _outputHandlerChain.Write(mLogEvent);
        }
    }
}