using mLogger.Config;
using mLogger.Factory;
using mLogger.Logger;
using mLogger.Outputs;
using Moq;
using Xunit;

namespace mLogger.Test
{
    public class MLFactoriesShould
    {
        [Fact]
        public void MLoggerFactoryShoudlReturnCorrectValue()
        {
            var config = new Mock<IMLoggerConfig>();
            var fac = new MLoggerFactory(config.Object);

            var sut = fac.CreateMLogger();

            Assert.NotNull(sut);
            Assert.IsType<MLogger>(sut);
        }

        [Fact]
        public void ConsoleLogOutputHandlerShoudlReturnCorrectValue()
        {
            var config = new Mock<IMLoggerConfig>();
            var writer = new Mock<IWriteToOutput>();

            ILogOutputHandler sut = LogToConsole.GetInstance(config.Object, writer.Object);

            //var sut = fac.CreateHandler(config.Object, path.Object, writer.Object);

            Assert.NotNull(sut);
            Assert.IsType<LogToConsole>(sut);
        }

        [Fact]
        public void XmlLogOutputHandlerShoudlReturnCorrectValue()
        {
            var config = new Mock<IMLoggerConfig>();
            var writer = new Mock<IWriteToOutput>();
            ILogOutputHandler sut = LogToXml.GetInstance(config.Object, writer.Object);

            Assert.NotNull(sut);
            Assert.IsType<LogToXml>(sut);
        }

        [Fact]
        public void JsonLogOutputHandlerShoudlReturnCorrectValue()
        {
            var config = new Mock<IMLoggerConfig>();
            var writer = new Mock<IWriteToOutput>();
            ILogOutputHandler sut = LogToJson.GetInstance(config.Object, writer.Object);


            Assert.NotNull(sut);
            Assert.IsType<LogToJson>(sut);
        }
    }
}
