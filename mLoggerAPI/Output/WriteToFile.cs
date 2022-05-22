using mLoggerAPI.Config;
using mLoggerAPI.LogEvent;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace mLoggerAPI.Output
{
    public class WriteToFile : IWriteToOutput
    {
        private readonly ConfigLogger _configLogger;
        private readonly string _basePath;
        private readonly string _fullFilePath;
        private readonly object _lock = new();

        public WriteToFile(ConfigLogger configLogger, string basePath)
        {
            _configLogger = configLogger ?? throw new ArgumentNullException(nameof(configLogger));
            _basePath = basePath ?? throw new ArgumentNullException(nameof(basePath));

            _fullFilePath = Path.Combine(_basePath, _configLogger.SubFolder, _configLogger.Format.ToString() + "." + _configLogger.Format.ToString());
        }
        public void Write(MLogEvent eventToLog)
        {
            lock (_lock)
            {

                if (File.Exists(_fullFilePath))
                {
                    if (_configLogger.Format == Enums.LogFormat.xml)
                    {
                        var elementToAppend = CreateXElement(eventToLog);

                        XDocument doc = XDocument.Load(_fullFilePath);
                        doc.Element("LogEvents")?.Add(elementToAppend);
                        doc.Save(_fullFilePath);
                    }
                    else if (_configLogger.Format == Enums.LogFormat.json)
                    {
                        var filecontent = File.ReadAllText(_fullFilePath);

                        JsonFileObjectStructure LogEvents = JsonSerializer.Deserialize<JsonFileObjectStructure>(filecontent);
                        LogEvents?.LogEvents.Add(eventToLog);
                        var serializedStringToWrite = JsonSerializer.Serialize(LogEvents);

                        File.WriteAllText(_fullFilePath, serializedStringToWrite);
                    }

                }
                else
                {
                    if (_configLogger.Format == Enums.LogFormat.xml)
                    {
                        var elementToAppend = CreateXElement(eventToLog);
                        XDocument doc = new XDocument( new XElement("LogEvents"));
                        doc.Element("LogEvents")?.Add(elementToAppend);
                        doc.Save(_fullFilePath);

                    }
                    else if (_configLogger.Format == Enums.LogFormat.json)
                    {
                        List<MLogEvent> LogEvents = new()
                        {
                            eventToLog
                        };
                        var jsonObject = new JsonFileObjectStructure(LogEvents);

                        var serializedStringToWrite = JsonSerializer.Serialize(jsonObject);
                        File.WriteAllText(_fullFilePath, serializedStringToWrite);
                    }
                }

            }
        }

        private XElement CreateXElement(MLogEvent mLogEvent)
        {    
            return new XElement("LogEvent",
                            new XElement("LogLevel", mLogEvent.LogLevel),
                            new XElement("Message", mLogEvent.Message),
                            new XElement("Timestamp", mLogEvent.Timestamp));
        }

    }
}
