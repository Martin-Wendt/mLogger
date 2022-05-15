using mLogger.Logger;

namespace mLogger.Factory
{
    public interface IMLoggerFactory
    {
        IMLogger CreateMLogger();
    }
}