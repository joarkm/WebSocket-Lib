
using WebSocketLib.Constants;

namespace WebSocketLib {
    class WebSocket {


    public WebSocket() {}

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
}


}