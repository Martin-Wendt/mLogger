using mLoggerAPI.Logger;

namespace mLogger.Test
{
    public class MLoggerShould
    {
        private MLogger Sut { get; set; }

        //public MLoggerShould()
        //{
        //    var Config = new Mock<IMLoggerConfig>();
        //    var OutputHandler = new Mock<ILogHandler>();
        //    Sut = MLogger.GetInstance(Config.Object, OutputHandler.Object);
        //}

        //[Fact]
        //public void BeSingleton()
        //{
        //    var config = new Mock<IMLoggerConfig>();
        //    var outputHandler = new Mock<ILogHandler>();
        //    MLogger sut1 = MLogger.GetInstance(config.Object, outputHandler.Object);
        //    MLogger sut2 = MLogger.GetInstance(config.Object, outputHandler.Object);

        //    Assert.Equal(sut1, sut2);
        //}


        //[Fact]
        //public void ExecuteLog()
        //{

        //    MLogger.Reset();

        //    var config = new MLoggerConfig(LogLevel.Verbose);
        //    var outputHandler = new Mock<ILogHandler>();

        //    Sut = MLogger.GetInstance(config, outputHandler.Object);
        //    var logevent = new MLogEvent("message", Enum.LogLevel.Debug);
        //    Sut.Log(logevent);

        //    outputHandler.Verify(x => x.Write(logevent), Times.Once);
        //}

        //[Fact]
        //public void NotExcuteLogLevelToLow()
        //{
        //    MLogger.Reset();

        //    var config = new MLoggerConfig(Enum.LogLevel.Fatal);
        //    var outputHandler = new Mock<ILogHandler>();
        //    Sut = MLogger.GetInstance(config, outputHandler.Object);
        //    var logevent = new MLogEvent("message", Enum.LogLevel.Verbose);

        //    Sut.Log(logevent);

        //    outputHandler.Verify(x => x.Write(logevent), Times.Never);

        //}

        //[Fact]
        //public void NotExcuteLogNoMessage()
        //{
        //    MLogger.Reset();
        //    var config = new MLoggerConfig(Enum.LogLevel.Fatal);
        //    var outputHandler = new Mock<ILogHandler>();
        //    Sut = MLogger.GetInstance(config, outputHandler.Object);
        //    var logevent = new MLogEvent("", Enum.LogLevel.Verbose);

        //    Sut.Log(logevent);

        //    outputHandler.Verify(x => x.Write(logevent), Times.Never);

        //}

        //[Fact]
        //public void WriteToOutput()
        //{
        //    MLogger.Reset();

        //    var writer = new Mock<IWriteToOutput>();
        //    var config = new MLoggerConfig(Enum.LogLevel.Verbose, @"c:\tst", true, true, true);
        //    var outputHandler = LogToConsole.GetInstance(config, writer.Object);
        //    var xmlLog = LogToXml.GetInstance(config, writer.Object);
        //    var jsonLog = LogToJson.GetInstance(config, writer.Object);


        //    Sut = MLogger.GetInstance(config, outputHandler);
        //    var logevent = new MLogEvent("awdawdawd", Enum.LogLevel.Verbose);

        //    outputHandler.SetSuccessor(xmlLog).SetSuccessor(jsonLog);

        //    //needed when all test are run, else stackoverflow exception
        //    jsonLog.SetSuccessor(null);

        //    Sut.Log(logevent);


        //    writer.Verify(x => x.WriteXmlToFile(It.IsAny<string>()), Times.Once);
        //    writer.Verify(x => x.WriteJsonToFile(It.IsAny<string>()), Times.Once);
        //    writer.Verify(x => x.WriteToConsole(It.IsAny<string>()), Times.Once);




        //}
    }
}


