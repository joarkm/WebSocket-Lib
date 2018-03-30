using System;
using System.Text;

using WebSocketLib;
using WebSocketLib.Constants;

namespace WebSocketLib.Simulation {

    public static class WebSocketClientService {

        //For testing...
        public static Frame ConstructClientFrame(FrameType frameType, byte[] payload, int mask_key)
        {
            if(frameType == FrameType.BINARY || frameType == FrameType.TEXT)
            {
                //Mask payload
                byte[] maskedPayload = new byte[payload.Length];
                byte [] _mask_key = new byte[4];
                for(int i=0; i<4; ++i)
                    _mask_key[i] = (byte)((mask_key >> 8*i) & 0xFF);
                for(int i=0; i<payload.Length; ++i)
                    maskedPayload[i] = (byte)(payload[i] ^ _mask_key[i%4]);

                Frame frame = null;
                if(frameType == FrameType.BINARY)
                    frame = new Frame(OpCode.BINARY, maskedPayload, mask_key);
                else
                    frame = new Frame(OpCode.TEXT, maskedPayload, mask_key);
                return frame;
            }
            else 
                throw new ArgumentException("Please supply either text or binary frametype.");
        }

        //For testing...
        public static Frame ConstructClientFrame(FrameType frameType, string payload, int mask_key)
        {
            Frame frame = null;
            if(frameType == FrameType.TEXT)
            {
                byte[] binaryPayload = Encoding.UTF8.GetBytes(payload);
                return ConstructClientFrame(frameType, binaryPayload, mask_key);
            }
            else
                throw new ArgumentException("Please supply text frametype.");
        }

    }

}