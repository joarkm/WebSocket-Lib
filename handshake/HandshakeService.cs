using System;
using System.Text;
using System.Security.Cryptography;

using WebSockets.Constants;
using WebSockets.HTTP.Request;

namespace WebSockets.HTTP.Handshake {


    public static class HandshakeService {

        public static string HandShake(WebSocketRequest request)
        {
            SHA1 sha1 = SHA1.Create();
            string concat = request.WebSocket_Key+Constants.Constants.GUID;
            byte[] toHash = Encoding.UTF8.GetBytes(concat);
            byte[] hash = sha1.ComputeHash(toHash);

            return System.Convert.ToBase64String(hash);
        }

    }

}