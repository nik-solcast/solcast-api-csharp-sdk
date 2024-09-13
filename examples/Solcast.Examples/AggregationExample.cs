using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class AggregationExample
    {
        public static async Task RunAggregationExample()
        {
            try
            {
                var aggregationClient = new AggregationClient();
                var outputParameters = new[] { "percentage", "pv_estimate" };

                // // Example for Live Aggregation
                // var liveAggregationResponse = await aggregationClient.GetLiveAggregation("country_total", "it_total", outputParameters);
                // Console.WriteLine("Live Aggregation Data:");
                // Console.WriteLine(liveAggregationResponse);

                // Example for Forecast Aggregation
                var forecastAggregationResponse = await aggregationClient.GetForecastAggregation("country_total", "it_total", outputParameters);
                Console.WriteLine("Forecast Aggregation Data:");
                Console.WriteLine(forecastAggregationResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AggregationExample: {ex.Message}");
            }
        }
    }
}
