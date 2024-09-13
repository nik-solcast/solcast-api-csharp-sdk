using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solcast.Models;

namespace Solcast.Clients
{
    public class LiveClient
    {
        private readonly HttpClient _httpClient;

        public LiveClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        public async Task<object> GetRadiationAndWeather(double latitude, double longitude, string[] outputParameters, string format = "csv")
        {
            var parameters = $"latitude={latitude}&longitude={longitude}&output_parameters={string.Join(",", outputParameters)}&format={format}";
            var response = await _httpClient.GetAsync($"{SolcastUrls.LiveRadiationAndWeather}?{parameters}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}, Content: {content}");  // Add this log to check the status code and content

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Console.WriteLine("Unauthorized Access - Invalid API Key."); // Add this to see if the block is reached
                    throw new UnauthorizedAccessException("Invalid API key.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new UnauthorizedAccessException("Access forbidden. Invalid permissions.");
                }

                // Capture general HTTP exceptions
                throw new HttpRequestException($"API call failed with status code: {response.StatusCode} - {content}");
            }

            if (format == "json")
            {
                return JsonConvert.DeserializeObject<RadiationAndWeatherResponse>(content);
            }

            return content;
        }
    }
}
