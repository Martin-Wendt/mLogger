
namespace mLogger.Outputs
{
    public interface IWriteToOutput
    {
        void WriteXmlToFile(string xml);
        void WriteJsonToFile(string json);
        void WriteToConsole(string output);
    }
}