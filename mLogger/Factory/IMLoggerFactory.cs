using mLogger.Logger;

namespace mLogger.Factory
{
    public interface IMLoggerFactory
    {
        /// <summary>
        /// Create mlogger instance
        /// </summary>
        /// <returns></returns>
        public IMLogger CreateMLogger();
    }
}