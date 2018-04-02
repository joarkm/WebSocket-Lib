using System;
using Xunit;

using WebSocketLib;
using WebSocketLib.Constants;

namespace ServerLib.Tests
{
    public class ToStringTest
    {
        [Fact]
        public void PrintsBinary()
        {
            Frame binaryFrame =null;
            Exception ex = Record.Exception( 
                () => binaryFrame = FrameBuilder.NewBinaryFrame(new byte[]
                {
                    0b01011101,
                    0b11111111
                })
            );
            String stringyfied = binaryFrame.ToString();
            Console.WriteLine(stringyfied);
            Assert.NotNull(stringyfied);
        }

    }
}
