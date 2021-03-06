﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    public class Server
    {

        public static void Start()
        {
            int port = 7777;
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();

            TcpClient socket = listener.AcceptTcpClient();

            using (socket)
            {
                DoClient(socket);
            }

        }

        public static void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            var wordsSent = 0;
            string inputLine = "";
            while (inputLine != null)
            {
                inputLine = reader.ReadLine();
                writer.WriteLine($"string: {inputLine}");
                Console.WriteLine($"string: {inputLine}");

                var wordsArray = inputLine.Split(" ");

                wordsSent = wordsSent + wordsArray.Length;

                Console.WriteLine($"Number of words sent: {wordsSent}");
            }
            Console.WriteLine("Server disconnected...");
        }
    }
}
