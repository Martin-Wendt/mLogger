
namespace mLoggerAPI.Config
{
    public interface IMLoggerConfig
    {
        List<ConfigLogger> Outputs { get; set; }
        public string BasePath { get; set; }
    }
}