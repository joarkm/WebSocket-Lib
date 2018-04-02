
namespace WebSocketLib {

    //Used for constructing masked client Frame objects
    public static class ClientFrameBuilder
    {
        public static Frame NewBinaryFrame(byte[] payload, int mask_key)
        {
            return new Frame(payload, mask_key);
        }
        public static Frame NewTextFrame(string payload, int mask_key)
        {
            return new Frame(payload, mask_key);
        }
        public static PingFrame NewPingFrame(string payload, int mask_key)
        {
            return new PingFrame(payload, mask_key);
        }
    }

}