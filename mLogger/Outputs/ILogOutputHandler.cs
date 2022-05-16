// See https://aka.ms/new-console-template for more information

using mLogger.LogEvent;

namespace mLogger.Outputs
{
    /// <summary>
    /// Outputter interface
    /// </summary>
    public interface ILogOutputHandler
    {
        /// <summary>
        /// Write Log event to output format
        /// </summary>
        /// <param name="mLogEvent">event to log</param>
        public void Write(IMLogEvent mLogEvent);
        /// <summary>
        /// Successor - Chain of responsibility
        /// </summary>
        /// <param name="successor">next instance</param>
        /// <returns>next instance</returns>
        ILogOutputHandler SetSuccessor(ILogOutputHandler successor);

    }
}