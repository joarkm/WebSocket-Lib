using System;
using Xunit;

using WebSocketLib.ServerLib.Helpers;
using ServerLib.Tests.Fixtures;

namespace ServerLib.Tests
{
    public class FramePrinterTest : IClassFixture<FrameFixture>
    {
        public FrameFixture fixture;

        public FramePrinterTest(FrameFixture frameFixture)
        {
            fixture = frameFixture;
        }

        //Helper methods
        private string[] SplitString(string toSplit)
        {
            var strings = toSplit.Split(
                //Using whitespaces and tabs as delimeters
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            return strings;
        }

        [Fact]
        public void PrintsBinary()
        {
            var byteStrings = SplitString(FramePrinter.PrintPayloadBinary(fixture.BinaryFrame.Payload));

            var regex = fixture.BinaryRegex;
            foreach (string byteString in byteStrings)
            {
                bool matches = (byteString.Length == 8) && regex.IsMatch(byteString);
                Assert.True(matches);
            }
        }

        [Fact]
        public void PrintsHex()
        {
            var hexStrings = SplitString(FramePrinter.PrintPayloadHex(fixture.BinaryFrame.Payload));

            var regex = fixture.HexRegex;
            foreach (string hexString in hexStrings)
            {
                bool matches = (hexString.Length == 2) && regex.IsMatch(hexString);
                Assert.True(matches);
            }
        }

    }
}
