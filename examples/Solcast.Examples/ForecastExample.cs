using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class ForecastExample
    {
        public static async Task RunForecastExample()
        {
            try
            {
                var forecastClient = new ForecastClient();
                var response = await forecastClient.GetForecastRadiationAndWeather(-33.856784, 151.215297, new[] { "dni", "ghi", "air_temp" }, "csv");

                Console.WriteLine("Forecast Radiation and Weather Data (CSV):");
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ForecastExample: {ex.Message}");
            }
        }
    }
}
