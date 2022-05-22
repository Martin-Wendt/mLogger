// See https://aka.ms/new-console-template for more information

using mLoggerAPI.LogEvent;

namespace mLoggerAPI.Outputs
{
    /// <summary>
    /// Outputter interface
    /// </summary>
    public interface ILogHandler
    {
        /// <summary>
        /// Write Log event to output format
        /// </summary>
        /// <param name="mLogEvent">event to log</param>
        public void Write(MLogEvent mLogEvent);
        /// <summary>
        /// Successor - Chain of responsibility
        /// </summary>
        /// <param name="successor">next instance</param>
        /// <returns>next instance</returns>
        ILogHandler SetSuccessor(ILogHandler successor);
    }
}