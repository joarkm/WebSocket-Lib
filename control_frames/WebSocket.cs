using System;
using System.Collections.Generic;

using WebSocketLib.Constants;

namespace WebSocketLib {

    public class WebSocket {

        public WebSocket() {}

        public Queue<Frame> receiveQueue { get; } = new Queue<Frame>();

        public void SendPing()
        {
            //Construct ping frame…
            WebSocketService.ConstructFrame(FrameType.PING);
        }

        public Frame SendPing2()
        {
            //Construct ping frame…
            return WebSocketService.ConstructFrame(FrameType.PING);
        }

        //Method purely for testing behaviour
        public void AddToQueue(Frame frame)
        {
            receiveQueue.Enqueue(frame);
        }


    }


}