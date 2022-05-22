using mLoggerAPI.LogEvent;

namespace mLoggerAPI.Output
{
    public interface IWriteToOutput
    {
        /// <summary>
        /// write to xml file
        /// </summary>
        /// <param name="xml">serialized xml</param>
        void Write(MLogEvent eventToLog);
    }
}