using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solcast.Clients
{
    public class TmyClient
    {
        private readonly HttpClient _httpClient;

        public TmyClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        // Method for Radiation and Weather with additional parameters
        public async Task<string> GetRadiationAndWeather(double latitude, double longitude, string format = "csv", Dictionary<string, string> additionalParameters = null)
        {
            var parameters = $"latitude={latitude}&longitude={longitude}&format={format}";

            // Append additional parameters dynamically
            if (additionalParameters != null)
            {
                parameters += "&" + string.Join("&", additionalParameters.Select(p => $"{p.Key}={p.Value}"));
            }

            var response = await _httpClient.GetAsync($"{SolcastUrls.TmyRadiationAndWeather}?{parameters}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Method for Rooftop PV Power with additional parameters
        public async Task<string> GetRooftopPvPower(double latitude, double longitude, string format = "csv", Dictionary<string, string> additionalParameters = null)
        {
            var parameters = $"latitude={latitude}&longitude={longitude}&format={format}";

            // Append additional parameters dynamically
            if (additionalParameters != null)
            {
                parameters += "&" + string.Join("&", additionalParameters.Select(p => $"{p.Key}={p.Value}"));
            }

            var response = await _httpClient.GetAsync($"{SolcastUrls.TmyRooftopPvPower}?{parameters}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
