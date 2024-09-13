using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solcast.Models;

namespace Solcast.Clients
{
    public class ForecastClient
    {
        private readonly HttpClient _httpClient;

        public ForecastClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        // Method to get irradiance and weather forecasts (radiation and weather)
        public async Task<object> GetForecastRadiationAndWeather(double latitude, double longitude, string[] outputParameters, string format = "csv")
        {
            var parameters = $"latitude={latitude}&longitude={longitude}&output_parameters={string.Join(",", outputParameters)}&format={format}";
            var response = await _httpClient.GetAsync($"{SolcastUrls.ForecastRadiationAndWeather}?{parameters}");

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Invalid API key.");
                }

                throw new Exception($"API call failed with status code: {response.StatusCode} - {content}");
            }

            if (format == "json")
            {
                return JsonConvert.DeserializeObject<RadiationAndWeatherResponse>(content);
            }

            return content;
        }

        // Method to get rooftop PV power forecasts
        public async Task<object> GetForecastRooftopPvPower(double latitude, double longitude, string[] outputParameters, string format = "csv")
        {
            var parameters = $"latitude={latitude}&longitude={longitude}&output_parameters={string.Join(",", outputParameters)}&format={format}";
            var response = await _httpClient.GetAsync($"{SolcastUrls.ForecastRooftopPvPower}?{parameters}");

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Invalid API key.");
                }

                throw new Exception($"API call failed with status code: {response.StatusCode} - {content}");
            }

            if (format == "json")
            {
                return JsonConvert.DeserializeObject<RadiationAndWeatherResponse>(content);
            }

            return content;
        }

        // Method to get advanced PV power forecasts
        public async Task<object> GetForecastAdvancedPvPower(int resourceId, string format = "csv")
        {
            var parameters = $"resource_id={resourceId}&format={format}";
            var response = await _httpClient.GetAsync($"{SolcastUrls.ForecastAdvancedPvPower}?{parameters}");

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Invalid API key.");
                }

                throw new Exception($"API call failed with status code: {response.StatusCode} - {content}");
            }

            if (format == "json")
            {
                return JsonConvert.DeserializeObject<RadiationAndWeatherResponse>(content);
            }

            return content;
        }
    }
}
