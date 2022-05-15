// See https://aka.ms/new-console-template for more information

using mLogger.LogEvent;

namespace mLogger.Outputs
{
    /// <summary>
    /// Outputter interface
    /// </summary>
    public interface ILogOutputHandler
    {
        public void Write(IMLogEvent mLogEvent);
        ILogOutputHandler SetSuccessor(ILogOutputHandler successor);

    }
}