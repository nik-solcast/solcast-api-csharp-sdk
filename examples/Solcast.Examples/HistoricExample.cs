using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class HistoricExample
    {
        public static async Task RunHistoricExample()
        {
            var historicClient = new HistoricClient();
        
            double latitude = -33.856784;
            double longitude = 151.215297;
            string start = "2022-06-01T06:00";
            string duration = "P1D";
        
            try
            {
                var response = await historicClient.GetRadiationAndWeather(latitude, longitude, start, duration: duration);
            
                Console.WriteLine("Response received:");
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in HistoricExample: {ex.Message}");
            }
        }
    }
}
