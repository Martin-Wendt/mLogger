// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;

namespace mLoggerAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LogLevel
    {
        Verbose,
        Debug,
        Information,
        Warning,
        Error,
        Fatal,
    }
}