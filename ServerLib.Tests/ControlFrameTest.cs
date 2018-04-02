using System;
using Xunit;

using WebSocketLib;
using WebSocketLib.Constants;

namespace ServerLib.Tests
{
    public class ControlFrameTest
    {
        [Fact]
        public void CanCreateTextFrame()
        {
            Exception ex = Record.Exception( () => new Frame("test frame") );
            Assert.Null(ex); //Assert exception not raised
        }

        [Fact]
        public void CanCreateMaskedTextFrame()
        {
            Exception ex = Record.Exception( () => new Frame("test frame", 1421) );
            Assert.Null(ex); //Assert exception not raised
        }

        [Fact]
        public void CannotCreateClientControlFrameWithTooLongPayload()
        {
            Assert.Throws<ArgumentException>( () => new ControlFrame(new string('*', 126), 14412) );
        }
        
    }
}
