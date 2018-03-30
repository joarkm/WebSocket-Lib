using System;

using WebSocket.Constants;
using WebSocket;

class Program
{
    static void Main(string[] args)
    {
        Frame frame = new Frame(OpCode.PING);
        Frame frame2 = new Frame(0x9);
        Frame frame3 = new Frame();

        Console.WriteLine(frame);
        Console.WriteLine(frame2);
        Console.WriteLine(frame3);
    }
}
