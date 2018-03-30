
using WebSocketLib.Constants;

namespace WebSocketLib {
    public static class WebSocketService {

        public static Frame ConstructFrame(FrameType frameType)
        {
            Frame frame = null;
            if(frameType == FrameType.PING)
                frame = new Frame(OpCode.PING);
        
            return frame;
        }
        

        public static void ReadFrame(Frame frame)
        {
            if(frame.hasPayload)
            {
                if(!frame.Masked)
                {
                    //Drop websocket connection
                }
            }
        }

    }
}
