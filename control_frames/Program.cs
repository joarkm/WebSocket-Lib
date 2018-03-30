using System;

using WebSocketLib;
using WebSocketLib.Constants;
using WebSocketLib.Simulation;

class Program
{

    
    static void Main(string[] args)
    {
        Program p = new Program();

        Console.WriteLine("--TEST 1--\n");
        //p.test1();
        Console.WriteLine("\n--TEST 2--\n");
        //p.test2();
        Console.WriteLine("\n--TEST 3--\n");
        //p.test3();
        Console.WriteLine("\n--TEST 4--\n");
        p.test4();
    }

    void test1()
    {
        Frame frame = new Frame(OpCode.PING);
        Frame frame2 = new Frame(0x9);
        Frame frame3 = new Frame();
        //Frame frame4 = new Frame(0x3);

        Console.WriteLine(frame);
        Console.WriteLine(frame2);
        Console.WriteLine(frame3);
    }

    void test2()
    {
        Frame frame = WebSocketService.ConstructFrame(FrameType.PING);
        Console.WriteLine(frame);
    }
    void test3()
    {
        WebSocket webSocket = new WebSocket();
        Frame frame = webSocket.SendPing2();
        Console.WriteLine(frame);
    }

    void test4()
    {
        Frame frame = WebSocketClientService.ConstructClientFrame(FrameType.TEXT, "Hei på deg", 176827);
        Console.WriteLine("Masked frame sendt from client to server:");
        Console.WriteLine(frame);
        Console.WriteLine("Unmasked frame decoded server-side:");
        Console.WriteLine(frame.GetUnmaskedFrame());
    }
}
