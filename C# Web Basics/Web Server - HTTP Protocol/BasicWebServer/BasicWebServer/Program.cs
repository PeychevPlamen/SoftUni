using System;
using System.Net;
using System.Net.Sockets;

namespace BasicWebServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var port = 8080;

            var serverListener = new TcpListener(ipAddress, port);
            serverListener.Start();

            Console.WriteLine("Hello World!");
        }
    }
}