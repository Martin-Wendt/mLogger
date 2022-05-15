using mLogger.PathCreation;
using System.Xml;

namespace mLogger.Outputs
{
    public class WriteToOutput : IWriteToOutput
    {
        private readonly IPathCreator _pathCreator;
        private static string XmlFilename => DateTimeOffset.Now.ToString("yyyyMMdd_HH") + ".xml";
        private static string JsonFileName => DateTimeOffset.Now.ToString("yyyyMMdd") + ".json";
        public WriteToOutput(IPathCreator pathCreator)
        {
            _pathCreator = pathCreator ?? throw new ArgumentNullException(nameof(pathCreator));
        }

        public void WriteJsonToFile(string jsonString)
        {
            var subFolder = "json";
            _pathCreator.EnsurePathExsists(subFolder);
            var fullFilePath = Path.Combine(_pathCreator.FolderPath, subFolder, JsonFileName);

            using StreamWriter file = WriteToFile(jsonString, fullFilePath);
        }


        public void WriteXmlToFile(string xml)
        {
            var subFolder = "xml";
            _pathCreator.EnsurePathExsists(subFolder);
            var fullFilePath = Path.Combine(_pathCreator.FolderPath,subFolder, XmlFilename);

            using StreamWriter file = WriteToFile(xml, fullFilePath);       
        }

        public void WriteToConsole(string output)
        {
            Console.WriteLine(output);
        }

        private static StreamWriter WriteToFile(string jsonString, string fullFilePath)
        {
            StreamWriter file = new(fullFilePath, append: true);
            file.WriteLineAsync(jsonString);

            file.Close();
            return file;
        }
    }
}
