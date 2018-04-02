using System;

using WebSocketLib.Constants;

namespace WebSocketLib {

    public class PingFrame : ControlFrame
    {
        public override byte OpCode { get {return (byte)Constants.OpCode.PING; } 
            protected set { OpCode = value; }
        }
        public PingFrame() :base() { }
        public PingFrame(string payload) : base(payload) { }
        public PingFrame(string payload, int mask_key) : base(payload, mask_key) {}
        public PingFrame(byte[] payload) : base(payload) {}
        public PingFrame(byte[] payload, int mask_key) : base(payload, mask_key) {}

    }

}