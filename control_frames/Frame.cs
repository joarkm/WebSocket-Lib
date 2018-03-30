using System;
using System.Linq;
using System.Text;

using WebSocketLib.Constants;

namespace WebSocketLib {

    // This class is not intended to be used directly

    public class Frame {
    
        public byte FIN { get; private set; } = 0x0;
        public byte RSV1 { get; private set; } = 0x0;
        public byte RSV2 { get; private set; } = 0x0;
        public byte RSV3 { get; private set; } = 0x0;

        public byte OpCode { get; private set; }
        public bool Masked { get; private set; }
        public byte PayloadLen { get; private set; }
        public byte[] Payload { get; private set; }
        public byte[] Mask_Key { get; private set; }
        
        /* Has properties needed since we can't distinguish
         * between a byte property that has not been set
         * (defaults to 0) and a byte property that has 
         * been set to 0 intentionally.
         */

        public bool hasPayload => PayloadLen > 0;

        private void setFIN() { FIN = 0x1; }

        public Frame() {}

        public Frame(OpCode opcode) {
            switch (opcode)
            {
                case Constants.OpCode.TEXT:
                {
                    throw new ArgumentException("Please use a constructor that accepts payload data.");
                }

                case Constants.OpCode.CONNECTION_CLOSE:
                setFIN();
                break;

                default:
                throw new ArgumentException("Please use a suitable constructor.");
            }
            OpCode = (byte)opcode;
        }

        
        public Frame(byte opcode) {
            if(opcode == (byte)Constants.OpCode.CONNECTION_CLOSE)
                setFIN();
            //Check to see if opcode provided is of any of the allowed values
            if( AllowedValues.OpCodes.Any(et => (byte)et == opcode) )
                OpCode = opcode;
            else
                throw new ArgumentException("Opcode provided is invalid. Please refer to https://tools.ietf.org/html/rfc6455#section-5.2 for valid opcodes.");
        }

        public Frame(OpCode opCode, byte[] payload, int mask_key) {
            // Extensive validation not done here atm

            if(opCode == Constants.OpCode.TEXT) OpCode = (byte)Constants.OpCode.TEXT;
            else OpCode = (byte)Constants.OpCode.BINARY;
            Masked = true;
            Mask_Key = new byte[4];
            for(int i=0; i<4; ++i)
                Mask_Key[i] = (byte)((mask_key >> 8*i) & 0xFF);
            Payload = payload;
            PayloadLen = (byte)Payload.Length;
        }

        public Frame GetUnmaskedFrame()
        {
            //Make a deep copy of this frame
            Frame unmaskedFrame = new Frame() {
                FIN = this.FIN,
                RSV1 = this.RSV1,
                RSV2 = this.RSV2,
                RSV3 = this.RSV3,
                OpCode = this.OpCode,
                Masked = false,
                PayloadLen = this.PayloadLen
            };

            unmaskedFrame.Payload = new byte[PayloadLen];
            for(int i=0; i<PayloadLen; ++i)
                unmaskedFrame.Payload[i] = (byte)(Payload[i] ^ Mask_Key[i%4]);

            return unmaskedFrame;

        }
        
        private string ToString(OpCode opcode)
        {
            string res  =   ((Byte)opcode).ToString("x").PadLeft(1,'0');
            res        +=   " (" + Enum.GetName( typeof(Constants.OpCode), opcode) + ')';
            return res;
        }

        public override string ToString()
        {
            string _FIN = ((Byte)FIN).ToString("x").PadLeft(1,'0');
            string _OpCode = ToString((Constants.OpCode)OpCode);
            string res  =   $"FIN: {_FIN}\n"
                        +   $"Opcode: {_OpCode}\n";
            if(hasPayload)
            {
                if(OpCode == (byte)Constants.OpCode.TEXT)
                {
                    string _Payload = Encoding.UTF8.GetString(Payload);
                    res += $"Payload: {_Payload}\n";
                }
                    
            }
            
            return res;

        }

    }

}
