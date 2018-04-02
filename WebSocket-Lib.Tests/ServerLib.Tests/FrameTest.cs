using System;
using Xunit;

using WebSocketLib;
using WebSocketLib.Constants;

namespace ServerLib.Tests
{
    public class FrameTest
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
        
    }
}
