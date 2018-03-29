using System;

using WebSocket.Constants;
using WebSocket;

class Program
{
    static void Main(string[] args)
    {
        Frame frame = new Frame(false, OpCode.PING);
        Frame frame2 = new Frame(false, 0x9);
        Frame frame3 = new Frame();

        Console.WriteLine(frame);
        Console.WriteLine(frame2);
        Console.WriteLine(frame3);
    }
}
