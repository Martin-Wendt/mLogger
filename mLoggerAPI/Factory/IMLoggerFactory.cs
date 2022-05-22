using mLoggerAPI.Logger;

namespace mLoggerAPI.Factory
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