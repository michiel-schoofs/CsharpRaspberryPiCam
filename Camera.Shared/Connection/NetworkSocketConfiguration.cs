using System.Net;

namespace Camera.Shared.Connection
{
    public class NetworkSocketConfiguration
    {
        public string ServerAddress { get; set; }
        public bool IsValidIp => IPAddress.TryParse(ServerAddress, out _);
        public int ServerPort { get; set; }

        public static NetworkSocketConfiguration Default => new NetworkSocketConfiguration
        {
            ServerAddress = "127.0.0.1",
            ServerPort = 3694
        };
    }
}
