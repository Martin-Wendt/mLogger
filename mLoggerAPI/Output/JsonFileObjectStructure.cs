using mLoggerAPI.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mLoggerAPI.Output
{
    public class JsonFileObjectStructure
    {
        public List<MLogEvent> LogEvents { get; set; }

        public JsonFileObjectStructure(List<MLogEvent> logEvents)
        {
            LogEvents = logEvents;
        }
    }
}
