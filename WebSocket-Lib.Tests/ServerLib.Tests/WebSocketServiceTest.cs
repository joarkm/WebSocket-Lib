using System;
using Xunit;

using WebSocketLib;
using WebSocketLib.Constants;

namespace ServerLib.Tests
{
    //WebSocketServiceTest
    public class WebSocketServiceTest
    {
        [Theory]
        [InlineData(FrameType.PING)]
        public void ValidFrameTypeShouldPass(FrameType frameType)
        {
            var result = WebSocketService.ConstructFrame(frameType);
            Assert.True(result is Frame);
        }
    }
}
