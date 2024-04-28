using Iot.Device.Camera.Settings;
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
           
        }
    }
}
