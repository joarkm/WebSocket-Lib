using System;
using System.Linq;
using System.Text;

using WebSocketLib.Constants;

namespace WebSocketLib {

    // Todo: Make abstract and derive classes from

    public class Frame {
    
        public byte FIN { get; protected set; } = 0x1;
        public byte RSV1 { get; protected set; } = 0x0;
        public byte RSV2 { get; protected set; } = 0x0;
        public byte RSV3 { get; protected set; } = 0x0;

        public virtual byte OpCode { get; protected set; }
        public bool Masked { get; protected set; }
        public virtual byte PayloadLen { get; protected set; }
        public virtual byte[] Payload { get; protected set; }
        public byte[] Mask_Key { get; protected set; }
        
        protected void SetMask(int mask_key)
        {
            Masked = true;
            Mask_Key = new byte[4];
            for(int i=0; i<4; ++i)
                Mask_Key[i] = (byte)((mask_key >> 8*i) & 0xFF);
        }
        
        /* Has properties needed since we can't distinguish
         * between a byte property that has not been set
         * (defaults to 0) and a byte property that has 
         * been set to 0 intentionally.
         */

        public bool hasPayload => PayloadLen > 0;
        protected void setFIN() { FIN = 0x1; }

        public Frame() {}
        public Frame(byte[] payload) {
            OpCode = (byte)(Constants.OpCode.BINARY);
            Payload = payload;
            PayloadLen = (byte)Payload.Length;
        }
        public Frame(byte[] payload, int mask_key) :this(payload) {
            SetMask(mask_key);
        }
        public Frame(string payload) {
            OpCode = (byte)(Constants.OpCode.TEXT);
            if (Encoding.UTF8.GetByteCount(payload) > 128)
                throw new NotImplementedException("Handling payload exeeding the size of one frame is as of yet not implemented.");
            
            Payload = Encoding.UTF8.GetBytes(payload);
            PayloadLen = (byte)Payload.Length;
        }
        public Frame(string payload, int mask_key) :this(payload) {
            SetMask(mask_key);
        }

        public virtual void ToUnmasked()
        {   
            for(int i=0; i<PayloadLen; ++i)
                Payload[i] ^= Mask_Key[i%4];
            Masked = false;
            Mask_Key = null;
        }
        
        protected string ToString(OpCode opcode)
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
                } else {
                    string _Payload = Convert.ToBase64String(Payload);
                    res += $"Payload (in base64-format): {_Payload}\n";
                    _Payload = string.Join( " ",
                    Payload.Select( x => Convert.ToString( x, 2 ).PadLeft( 8, '0' ) ) );
                    res += $"Payload: {_Payload}\n";
                }
                    
            }
            return res;

        }

    }

}
