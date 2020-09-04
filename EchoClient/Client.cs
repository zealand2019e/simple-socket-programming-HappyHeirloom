using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class Client
    {
        public static void Start()
        {
            int port = 7777;

            TcpClient client = new TcpClient("localhost", port);

            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) {AutoFlush = true};

            while (true)
            {
                Console.WriteLine("Enter text to send to server: ");
                string line = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"Sending {line} to server");
                Console.WriteLine();
                writer.WriteLine(line);
                string lineReceived = reader.ReadLine();
                Console.WriteLine($"Received {lineReceived} from server" );
                Console.WriteLine();
            }

        }
    }
}
