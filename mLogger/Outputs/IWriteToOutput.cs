
namespace mLogger.Outputs
{
    public interface IWriteToOutput
    {
        /// <summary>
        /// write to xml file
        /// </summary>
        /// <param name="xml">serialized xml</param>
        void WriteXmlToFile(string xml);
        /// <summary>
        /// write to json file
        /// </summary>
        /// <param name="json">serialized json</param>
        void WriteJsonToFile(string json);
        /// <summary>
        /// write to console
        /// </summary>
        /// <param name="output">string to output</param>
        void WriteToConsole(string output);
    }
}