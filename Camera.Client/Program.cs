using Camera.Shared.Connection;
using Iot.Device.Camera.Settings;
using Serilog;
namespace Camera.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new CommandOptionsBuilder()
              .WithTimeout(1)
              .WithVflip()
              .WithHflip()
              .WithPictureOptions(90, "jpg")
              .WithResolution(640, 480);

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs/client.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();


            NetworkSocketConfiguration configuration = NetworkSocketConfiguration.Default;
            NetworkSocket networkSocket = new NetworkSocket(configuration);
            networkSocket.StatListening();
        }
    }
}
