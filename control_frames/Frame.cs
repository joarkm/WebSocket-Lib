using System;
using System.Linq;

using WebSocket.Constants;

namespace WebSocket{

    // This class is not intended to be used directly

    public class Frame {
    
        public byte FIN { get; private set; } = 0x0;
        public byte RSV1 { get; private set; } = 0x0;
        public byte RSV2 { get; private set; } = 0x0;
        public byte RSV3 { get; private set; } = 0x0;
        /*
        /// Setter causes StackOverflow

        public byte OpCode
        { 
            get { return OpCode; } 
            private set
            {
                if(!(( AllowedValues.OpCodes.Any (enumType => (byte)enumType == value) )))
                    throw new ArgumentException("Opcode provided is invalid. Please refer to https://tools.ietf.org/html/rfc6455#section-5.2 for valid opcodes.");            
                OpCode = value;
            }
        }
        */

        public byte OpCode { get; private set; }
        
        /* Has properties needed since we can't distinguish
         * between a byte property that has not been set
         * (defaults to 0) and a byte property that has 
         * been set to 0 intentionally.
         */

        public bool hasPayload { get; private set; }

        private void setFIN() { FIN = 0x1; }

        public Frame() {}

        public Frame(OpCode opcode) {
            if(opcode == Constants.OpCode.CONNECTION_CLOSE)
                setFIN(); 
            OpCode = (byte)opcode;
        }

        
        public Frame(byte opcode) {
            if(opcode == (byte)Constants.OpCode.CONNECTION_CLOSE)
                setFIN(); 
            OpCode = opcode;
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
                        +   $"Opcode: {_OpCode}";
            
            return res;


        }

    }

}
