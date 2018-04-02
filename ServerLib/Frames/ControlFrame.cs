using System;
using System.Text;
using System.ComponentModel.DataAnnotations;

using WebSocketLib.Constants;

namespace WebSocketLib {

    public class ControlFrame : Frame
    {
        private byte[] _Payload;
        [MaxLength(125)]
        public override byte[] Payload { 
            get { return _Payload; } 
            protected set
            {
                if (value.Length > 125)
                    throw new ArgumentException("Control frames must have a payload size < 125 bytes.");
                _Payload = value;
            }
        }


        public ControlFrame() :base() {}
        public ControlFrame(string payload) : base(payload) {}
        public ControlFrame(string payload, int mask_key) : base(payload, mask_key) {
            
        }
        public ControlFrame(byte[] payload) : base(payload) {
            
        }
        public ControlFrame(byte[] payload, int mask_key) : base(payload, mask_key) {
            
        }

    }

}