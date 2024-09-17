using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solcast.Clients
{
    public class HistoricClient
    {
        private readonly HttpClient _httpClient;

        public HistoricClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        public async Task<string> GetRadiationAndWeather(double latitude, double longitude, string start, string format = "csv", string end = null, string duration = null, string period = null)
        {
            if ((end == null && duration == null) || (end != null && duration != null))
            {
                throw new Exception("Must specify exactly one of 'duration' or 'end'");
            }

            var parameters = $"latitude={latitude}&longitude={longitude}&start={start}&format={format}";
            
            if (end != null)
            {
                parameters += $"&end={end}";
            }
            else if (duration != null)
            {
                parameters += $"&duration={duration}";
            }
            else if (period != null)
            {
                parameters += $"&period={period}";
            }

            var response = await _httpClient.GetAsync($"{SolcastUrls.HistoricRadiationAndWeather}?{parameters}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetRooftopPvPower(double latitude, double longitude, string start, string format = "csv", string end = null, string duration = null)
        {
            if ((end == null && duration == null) || (end != null && duration != null))
            {
                throw new Exception("Must specify exactly one of 'duration' or 'end'");
            }

            var parameters = $"latitude={latitude}&longitude={longitude}&start={start}&format={format}";
            if (end != null)
            {
                parameters += $"&end={end}";
            }
            else if (duration != null)
            {
                parameters += $"&duration={duration}";
            }

            var response = await _httpClient.GetAsync($"{SolcastUrls.HistoricRooftopPvPower}?{parameters}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAdvancedPvPower(int resourceId, string start, string format = "csv", string end = null, string duration = null)
        {
            if ((end == null && duration == null) || (end != null && duration != null))
            {
                throw new Exception("Must specify exactly one of 'duration' or 'end'");
            }

            var parameters = $"resource_id={resourceId}&start={start}&format={format}";
            if (end != null)
            {
                parameters += $"&end={end}";
            }
            else if (duration != null)
            {
                parameters += $"&duration={duration}";
            }

            var response = await _httpClient.GetAsync($"{SolcastUrls.HistoricAdvancedPvPower}?{parameters}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
