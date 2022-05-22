namespace mLoggerAPI.Config
{
    public class MLoggerConfig : IMLoggerConfig
    {
        public string BasePath { get; set; }
        public List<ConfigLogger> Outputs { get; set; }

        public MLoggerConfig()
        {

        }
        public MLoggerConfig(List<ConfigLogger> outputs, string path = @"c:\logs")
        {
            BasePath = path;
            Outputs = outputs ?? throw new ArgumentNullException(nameof(outputs));
        }
    }
}