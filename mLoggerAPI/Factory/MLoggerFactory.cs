// See https://aka.ms/new-console-template for more information

using mLoggerAPI.Config;
using mLoggerAPI.Enums;
using mLoggerAPI.Logger;
using mLoggerAPI.Output;
using mLoggerAPI.Outputs;
using Newtonsoft.Json;

namespace mLoggerAPI.Factory
{
    public class MLoggerFactory : IMLoggerFactory
    {
        private readonly string configFileName = "config.json";
        private IMLoggerConfig _config;
        public List<LogHandler> logHandlers = new();

        public MLoggerFactory()
        {
            LoadConfigFile();
        }

        public IMLogger CreateMLogger()
        {
            //Base Path Creation
            EnsurePathExsists();
            // create handlers
            CreateHandlers();
            // set successor chain
            SetSuccessorChain();

            //Create logger + add first element of successor chain
            MLogger logger = new(logHandlers.First());


            return logger;
        }

        private void LoadConfigFile()
        {
            var baseDirectory = Directory.GetCurrentDirectory();

            var fullFilePath = Path.Combine(baseDirectory, configFileName);

            var conf = File.ReadAllText(fullFilePath);

            if (conf == null) throw new Exception("Config file not found!");

            //_config = JsonSerializer.Deserialize<MLoggerConfig>(conf);
            _config = JsonConvert.DeserializeObject<MLoggerConfig>(conf);

            if (_config is null) throw new Exception("failed to load config file");
        }

        private void CreateHandlers()
        {
            foreach (var handlerToBe in _config.Outputs)
            {
                var handler = new LogHandler(handlerToBe, CreateOutput(handlerToBe));
                logHandlers.Add(handler);
            }
        }

        private void SetSuccessorChain()
        {
            LogHandler? previous = null;

            foreach (var handler in logHandlers)
            {
                if (previous != null)
                {
                    previous.SetSuccessor(handler);
                }
                previous = handler;
            }
        }

        private void EnsurePathExsists()
        {
            foreach (var handlers in _config.Outputs)
            {
                if(handlers.SubFolder is not null)
                {
                var path = Path.Combine(_config.BasePath, handlers.SubFolder);

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                }
            }
        }

        private IWriteToOutput CreateOutput(ConfigLogger configLogger)
        {
            if (configLogger.Output == LogOutput.console) return new WriteToConsole();
            else if (configLogger.Output == LogOutput.file) return new WriteToFile(configLogger, _config.BasePath);
            throw new Exception("Output not found!");
        }
    }
}