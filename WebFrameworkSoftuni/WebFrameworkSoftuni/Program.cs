using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebFrameworkSoftuni
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var address = IPAddress.Parse("127.0.0.1");
            var port = 8080;

            var serverListener = new TcpListener(address, port);

            serverListener.Start();

            var connection = await serverListener.AcceptTcpClientAsync();

            Console.WriteLine($"Server started at port {port}");
            Console.WriteLine("Listening for requests.");
        }
    }
}
