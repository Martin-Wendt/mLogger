using FluentAssertions;
using mLogger.LogEvent;
using System;
using Xunit;

namespace mLogger.Test
{
    public class MLogEventShould
    {
        /// <summary>
        /// Constructor overloading - Exception
        /// </summary>
        [Fact]
        public void ShouldAcceptExceptionAsMessage()
        {
            var log = new MLogEvent(new Exception(), Enum.LogLevel.Verbose);

            log.Should().NotBeNull();
        }
        /// <summary>
        /// Constructor overloading - string
        /// </summary>
        [Fact]
        public void ShouldAcceptStringAsMessage()
        {
            var log = new MLogEvent("", Enum.LogLevel.Verbose);

            log.Should().NotBeNull();
        }
    }
}
