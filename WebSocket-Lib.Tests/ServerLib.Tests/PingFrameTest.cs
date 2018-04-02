using System;
using Xunit;

using WebSocketLib;
using WebSocketLib.Constants;

namespace ServerLib.Tests
{
    public class PingFrameTest
    {

        [Fact]
        public void CanCreatePingFrameWithPayload()
        {
            Exception ex = Record.Exception( () => new PingFrame("test frame") );
            Assert.Null(ex); //Assert exception not raised
        }

        [Fact]
        public void CanCreatePingFrameWithMaskedPayload()
        {
            Exception ex = Record.Exception( () => ClientFrameBuilder.NewPingFrame("test frame", 14412) );
            Assert.Null(ex); //Assert exception not raised
        }

        [Fact]
        public void CannotCreatePingFrameWithTooLongPayload()
        {
            Assert.Throws<ArgumentException>( () => ClientFrameBuilder.NewPingFrame(new string('*', 126), 14412) );
        }
        
    }
}
