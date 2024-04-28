using Camera.Shared.Connection;
using Serilog;

namespace Camera.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs/server.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            NetworkSocketConfiguration configuration = NetworkSocketConfiguration.Default;
            var socket = new NetworkSocket(configuration);
            socket.Connect();
            socket.Disconnect();
        }
    }
}
