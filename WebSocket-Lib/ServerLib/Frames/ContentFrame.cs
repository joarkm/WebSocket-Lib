using System;

using WebSocketLib.Constants;

namespace WebSocketLib {

    public abstract class ContentFrame : Frame
    {
        public ContentFrame(string payload) : base(payload) {}
        public ContentFrame(string payload, int mask_key) : base(payload, mask_key) {}
    }

}