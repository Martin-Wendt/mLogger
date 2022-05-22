using System.Text.Json.Serialization;

namespace mLoggerAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LogFormat
    {
        xml,
        json
    }
}
