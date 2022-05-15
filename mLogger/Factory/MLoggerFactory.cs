// See https://aka.ms/new-console-template for more information
using mLogger.Config;
using mLogger.Logger;
using mLogger.Outputs;
using mLogger.PathCreation;

namespace mLogger.Factory
{
    public class MLoggerFactory : IMLoggerFactory
    {
        private static IMLogger? _instance = null;
        private static readonly object padlock = new();
        private readonly IPathCreator _pathCreator;
        private readonly IMLoggerConfig _config;
        private readonly IWriteToOutput _writeToFile;

        public MLoggerFactory(IMLoggerConfig config)
        {
            _config = config;
            _pathCreator = new PathCreator(config.OutputPath);
            _writeToFile = new WriteToOutput(_pathCreator);
        }


        public IMLogger CreateMLogger()
        {
            if (_instance == null)
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        ILogOutputHandler outputHandlerChain = LogToXml.GetInstance(_config, _writeToFile);

                        outputHandlerChain
                            .SetSuccessor( LogToJson.GetInstance(_config, _writeToFile))
                            .SetSuccessor( LogToConsole.GetInstance(_config, _writeToFile));

                        _instance = MLogger.GetInstance(_config, outputHandlerChain);
                    }
                }
            }
            return _instance;
        }
    }
}