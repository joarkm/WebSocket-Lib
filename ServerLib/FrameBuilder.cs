namespace WebSocketLib {

    public static class FrameBuilder
    {
        public static Frame NewBinaryFrame(byte[] payload)
        {
            return new Frame(payload);
        }
        public static Frame NewTextFrame(string payload)
        {
            return new Frame(payload);
        }
        public static PingFrame NewPingFrame()
        {
            return new PingFrame();
        }
        public static PingFrame NewPingFrame(byte[] payload)
        {
            return new PingFrame(payload);
        }
        public static PingFrame NewPingFrame(string payload)
        {
            return new PingFrame(payload);
        }
    }


}