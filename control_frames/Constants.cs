namespace WebSocket.Constants {

    public enum OpCode: byte {

        TEXT = 0x1,
        BINARY = 0x2,
        // 0x3-7 are reserved for further non-control frames
        CONNECTION_CLOSE = 0x8,
        PING = 0x9,
        PONG = 0xA,
        // 0xB-F are reserved for further control frames

    };

    public static class AllowedValues {
        public static OpCode[] OpCodes = { OpCode.TEXT, OpCode.BINARY, OpCode.CONNECTION_CLOSE, OpCode.PING, OpCode.PONG };
    }

}