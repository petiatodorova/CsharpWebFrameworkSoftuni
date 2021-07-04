using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
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

            var networkStream = connection.GetStream();

            var content = $@"<h1>Здрасти от Петя!</h1>";

            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Content-Length: {contentLength}
Content-Type: text/html; charset=UTF-8

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBytes);

            connection.Close();
        }
    }
}
