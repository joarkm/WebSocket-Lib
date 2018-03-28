using System;

using WebSockets.HTTP.Request;
using WebSockets.HTTP.Handshake;

    class Program
    {
        static void Main(string[] args)
        {
            WebSocketRequest request = new WebSocketRequest {
                URI = "GET /chat HTTP/1.1",
                Host = "server.example.com",
                Upgrade = "websocket",
                WebSocket_Key = "amVnIHZpbCBrb2JsZSBtZWcgdGlsIGRlZw==",
                Origin = "http://example.com"
            };

            WebSocketRequest request2 = new WebSocketRequest {
                URI = "GET /chat HTTP/1.1",
                Host = "server.example.com",
                Upgrade = "websocket",
                WebSocket_Key = "dGhlIHNhbXBsZSBub25jZQ==",
                Origin = "http://example.com"
            };

            //var Server_Key = HandshakeService.HandShake(request);
            var Server_Key = HandshakeService.HandShake(request2);
            //expected value: "s3pPLMBiTxaQ9kYGzzhZRbK+xOo="

            Console.WriteLine("Client handshaked with server.");
            Console.WriteLine($"Server responded with key: {Server_Key}");
        }
    }
