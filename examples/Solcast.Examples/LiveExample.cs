using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class LiveExample
    {
        public static async Task RunLiveExample()
        {
            try
            {
                var liveClient = new LiveClient();
                var response = await liveClient.GetRadiationAndWeather(-33.856784, 151.215297, new[] { "dni", "ghi", "air_temp" }, "csv");

                Console.WriteLine("Live Radiation and Weather Data (CSV):");
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LiveExample: {ex.Message}");
            }
        }
    }
}
