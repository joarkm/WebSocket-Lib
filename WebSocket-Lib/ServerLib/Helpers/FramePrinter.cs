using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using WebSocketLib.Constants;
using System.Diagnostics.Contracts;

namespace WebSocketLib.ServerLib.Helpers
{
    public static class FramePrinter
    {


        public static String PrintOpCode(OpCode opCode)
        {
            string res = ((Byte)opCode).ToString("x").PadLeft(1, '0');
            res += " (" + Enum.GetName(typeof(Constants.OpCode), opCode) + ')';
            return res;
        }

        public static String PrintPayloadBinary(byte[] payload)
        {
            string res = string.Join(" ",
                    payload.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            return res;
        }

        public static String PrintPayloadHex(byte[] payload)
        {
            string res = string.Join(" ",
                    payload.Select(x => Convert.ToString(x, 16).PadLeft(2, '0')));
            return res;
        }

        static String GetStringRepresentation(Frame frame)
        {
            string _FIN = frame.FIN.ToString("x").PadLeft(1, '0');
            string _OpCode = PrintOpCode((Constants.OpCode)frame.OpCode);
            string res = $"FIN: {_FIN}\n"
                        + $"Opcode: {_OpCode}\n";
            if (frame.hasPayload)
            {
                if (frame.OpCode == (byte)Constants.OpCode.TEXT)
                {
                    string _Payload = Encoding.UTF8.GetString(frame.Payload);
                    res += $"Payload: {_Payload}\n";
                }
                else
                {
                    string _Payload = Convert.ToBase64String(frame.Payload);
                    res += $"Payload (in base64-format): {_Payload}\n";
                    _Payload = PrintPayloadBinary(frame.Payload);
                    res += $"Payload: {_Payload}\n";
                    _Payload = PrintPayloadHex(frame.Payload);
                    res += $"Payload: {_Payload}\n";
                }

            }
            return res;
        }
    }
}
