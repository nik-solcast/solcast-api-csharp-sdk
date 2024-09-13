using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class TmyExample
    {
        public static async Task RunTmyExample()
        {
            try
            {
                var tmyClient = new TmyClient();
                
                // Example with additional parameters (e.g., capacity)
                var additionalParams = new Dictionary<string, string>
                {
                    { "capacity", "3" }
                };

                // Example for Rooftop PV Power data
                var pvPowerResponse = await tmyClient.GetRooftopPvPower(-33.856784, 151.215297, "csv", additionalParams);
                Console.WriteLine("TMY Rooftop PV Power Data:");
                Console.WriteLine(pvPowerResponse);

                // // Example for Radiation and Weather data
                // var radiationResponse = await tmyClient.GetRadiationAndWeather(-33.856784, 151.215297, "csv", additionalParams);
                // Console.WriteLine("TMY Radiation and Weather Data:");
                // Console.WriteLine(radiationResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TmyExample: {ex.Message}");
            }
        }
    }
}
