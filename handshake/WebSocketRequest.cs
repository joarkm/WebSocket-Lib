
//using Microsoft.AspNetCore.Http;

namespace WebSockets.HTTP.Request{
    public class WebSocketRequest {

        public string URI { get; set; }
        public string Host { get; set; }
        public string Upgrade { get; set; }
        public string Connection { get; set; } = "Upgrade";
        public string WebSocket_Key;
        public string Origin;

        
        public WebSocketRequest() {}
        public WebSocketRequest( string _URI,
                        string _Host,
                        string _Upgrade,
                        string _Connection,
                        string _WebSocket_Key,
                        string _Origin) 
        {
            URI = _URI;
            Host = _Host;
            Upgrade = _Upgrade;
            Connection = _Connection;
            WebSocket_Key = _WebSocket_Key;
            Origin = _Origin;
        }
    }
}

