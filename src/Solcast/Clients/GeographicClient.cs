
using Newtonsoft.Json;
using Solcast.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solcast.Clients
{
    public class GeographicClient
    {
        private readonly HttpClient _httpClient;

        public GeographicClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        public async Task<ApiResponse<HorizonAngleResponse>> GetHorizonAngle(
            double? latitude,
            double? longitude,
            int? azimuthIntervals,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            parameters.Add("azimuthIntervals", azimuthIntervals.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.GeographicHorizonAngle + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<HorizonAngleResponse>(rawContent);
                return new ApiResponse<HorizonAngleResponse>(data, rawContent);
            }
            return new ApiResponse<HorizonAngleResponse>(null, rawContent);
        }
    }
}
