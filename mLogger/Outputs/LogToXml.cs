
using mLogger.Config;
using mLogger.LogEvent;
using System.Xml;
using System.Xml.Serialization;
namespace mLogger.Outputs
{
    /// <summary>
    /// Outputter
    /// 
    /// singleton
    /// </summary>
    public sealed class LogToXml : ILogOutputHandler
    {
        private static LogToXml? _instance = null;
        private static readonly object _lock = new();

        private ILogOutputHandler? _successor;
        private readonly IMLoggerConfig _config;
        private readonly IWriteToOutput _writeToFile;



        private LogToXml(IMLoggerConfig config, IWriteToOutput writeToFile)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _writeToFile = writeToFile ?? throw new ArgumentNullException(nameof(writeToFile));
        }

        public static LogToXml GetInstance(IMLoggerConfig config, IWriteToOutput writeToFile)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogToXml(config, writeToFile);
                    }
                }
            }

            return _instance;

        }
        public void Write(IMLogEvent mLogEvent)
        {
            if (_config.LogToXML)
            {
                XmlSerializer serializer = new(typeof(MLogEvent));

                using var stringWriter = new StringWriter();
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {

                    serializer.Serialize(writer, mLogEvent);
                }
                var xmlAsString = stringWriter.ToString();
                _writeToFile.WriteXmlToFile(xmlAsString);
            }

            _successor?.Write(mLogEvent);
        }

        public ILogOutputHandler SetSuccessor(ILogOutputHandler successor)
        {
            _successor = successor;
            return successor;
        }
    }
}