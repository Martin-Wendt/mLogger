using mLoggerAPI.LogEvent;

namespace mLoggerAPI.Output
{
    internal class WriteToConsole : IWriteToOutput
    {
        public void Write(MLogEvent eventToLog)
        {
            Console.WriteLine(eventToLog.ToString());
        }
    }
}
