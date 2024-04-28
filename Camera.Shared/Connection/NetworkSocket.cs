using System;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
namespace Camera.Shared.Connection
{
    public class NetworkSocket
    {
        private readonly TcpClient client;
        private readonly NetworkSocketConfiguration configuration;
        public NetworkSocket(NetworkSocketConfiguration configuration)
        {
            if(!configuration.IsValidIp)
            {
                throw new ArgumentException("Invalid IP address");
            }
            client = new TcpClient();
            this.configuration = configuration;
        }
        public void Connect()
        {
            Console.WriteLine("Connecting to server...");
            client.Connect(configuration.ServerAddress, configuration.ServerPort);
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from server...");
            client.Close();
        }

        public byte[] Read(byte[] buffer)
        {
            Console.WriteLine("Reading data from server...");
            int numBytes = client.GetStream().Read(buffer, 0, buffer.Length);
            return buffer.Take(numBytes).ToArray();
        }

        public void Send(byte[] data)
        {
            Console.WriteLine("Sending data to server...");
            client.GetStream().Write(data, 0, data.Length);
        }
    }
}
