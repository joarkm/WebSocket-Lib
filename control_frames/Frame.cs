using System;
using System.Linq;

using WebSocket.Constants;

namespace WebSocket{
    public class Frame {
    
        public byte FIN { get;  set; } = 0x0;
        public byte RSV1 { get; protected set; } = 0x0;
        public byte RSV2 { get; protected set; } = 0x0;
        public byte RSV3 { get; protected set; } = 0x0;
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
        public bool hasOpCode { get; private set; }

        private void setFIN()
        {
            FIN = 0x1;
        }

        public Frame() {}

        public Frame(bool fin, OpCode opcode) {
            if(fin) setFIN();
            OpCode = (byte)opcode;
            hasOpCode = true;
        }

        
        public Frame(bool fin, byte opcode) {
            if(fin) setFIN();
            OpCode = opcode;
            hasOpCode = true;
        }
        
        
        public override string ToString()
        {
            const string NOT_SET = "Not set";
            Byte b = FIN;
            string _FIN = b.ToString("x").PadLeft(1,'0');
            
            string _OpCode;
            if(hasOpCode)
            {
                b = OpCode;
                _OpCode = b.ToString("x").PadLeft(1,'0');
            } else {
                _OpCode = NOT_SET;
            }
            

            string res  =   $"FIN: {_FIN}\n"
                        +   $"Opcode: {_OpCode}";
            
            return res;


        }

    }

}
