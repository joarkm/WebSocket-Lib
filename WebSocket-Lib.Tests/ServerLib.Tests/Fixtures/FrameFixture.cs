using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

using WebSocketLib;

namespace ServerLib.Tests.Fixtures
{
    public class FrameFixture
    {
        public Frame BinaryFrame { get; }
        public Regex BinaryRegex { get;  }
        public Regex HexRegex { get; }
        public FrameFixture()
        {
            BinaryFrame = FrameBuilder.NewBinaryFrame(new byte[]
                {
                    0b01011101,
                    0b11111111,
                    0b10110001,
                    0b00110100
                }
            );

            BinaryRegex = new Regex("[0-1]{8}");
            HexRegex = new Regex("([0-9]|[a-f]){2}");

        }
        



    }
}
