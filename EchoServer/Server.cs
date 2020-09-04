using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class Server
    {

        public static void Start()
        {
            int port = 7;
            TcpClient client = new TcpClient("localhost",  port);
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);

            using (client)
            {
                DoClient(client);
            }

        }

        public static void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            Console.WriteLine("Enter text to send to server");
            string line = Console.ReadLine();
            Console.WriteLine($"Sending {line} to server");
            writer.WriteLine(line);
            string lineReceived = reader.ReadLine();
            Console.WriteLine($"Received {lineReceived} from server");
        }
    }
}
