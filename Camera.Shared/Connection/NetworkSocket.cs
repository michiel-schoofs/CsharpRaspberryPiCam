using Serilog;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
namespace Camera.Shared.Connection
{
    public class NetworkSocket
    {
        private  TcpClient client;
        private readonly NetworkSocketConfiguration configuration;
        private readonly TcpListener listener;
        

        public NetworkSocket(NetworkSocketConfiguration configuration)
        {
            if(!configuration.IsValidIp)
            {
                throw new ArgumentException("Invalid IP address");
            }
            client = new TcpClient();
            listener = new TcpListener(IPAddress.Parse(configuration.ServerAddress), configuration.ServerPort);
            this.configuration = configuration;
        }

        public void StatListening()
        {
            try
            {
                Log.Information("Starting to listen on {ip}:{port}", configuration.ServerAddress, configuration.ServerPort);
                listener.Start();
                client = listener.AcceptTcpClient();
            } catch (Exception ex)
            {
                Log.Error(ex, "Error connecting to server");
                throw;
            }
        }

        public void Connect()
        {
            try {                
                Log.Information("Connecting to server {ip}:{port}", configuration.ServerAddress, configuration.ServerPort);
                client.Connect(configuration.ServerAddress, configuration.ServerPort);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error connecting to server");
                throw;
            }
        }

        public void Disconnect()
        {
            Log.Information("Disconnecting from server...");
            client.Close();
        }

        public byte[] Read(byte[] buffer)
        {
            Log.Information("Reading data from server...");
            int numBytes = client.GetStream().Read(buffer, 0, buffer.Length);
            Log.Debug("Number of bytes read {length}", numBytes);
            return buffer.Take(numBytes).ToArray();
        }
        public void Send(byte[] data)
        {
            Log.Debug("Number of bytes to send {length}", data.Length);
            Log.Information("Sending data to server...");
            client.GetStream().Write(data, 0, data.Length);
        }
    }
}
