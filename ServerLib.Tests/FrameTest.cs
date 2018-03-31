using System;
using Xunit;

using WebSocketLib;
using WebSocketLib.Constants;

namespace ServerLib.Tests
{
    public class FrameTest
    {

        [Theory]
        [InlineData(OpCode.PING)]
        public void ValidOpCodeShouldPass(OpCode opCode)
        {
            Exception ex = Record.Exception( () => new Frame(opCode) );
            Assert.Null(ex); //Assert exception not raised
        }

        /*
        [Theory]
        [InlineData(-1)]
        [InlineData(0xF1)]
        [InlineData(0x3)]
        public void InvalidOpCodeShouldNotReturnFrame(byte opCode)
        {
            byte _opCode = (byte)opCode;
            Assert.Throws<ArgumentException>(delegate { new Frame(_opCode); } );
        }
        */
        
    }
}
