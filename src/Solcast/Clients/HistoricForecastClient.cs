
using Newtonsoft.Json;
using Solcast.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solcast.Clients
{
    public class HistoricForecastClient
    {
        private readonly HttpClient _httpClient;

        public HistoricForecastClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        public async Task<ApiResponse<HistoricForecastRadiationAndWeatherResponse>> GetRadiationAndWeather(
            string start,
            double? latitude,
            double? longitude,
            string leadTime = null,
            string end = null,
            string duration = null,
            string timeZone = null,
            string period = null,
            float? tilt = null,
            float? azimuth = null,
            string arrayType = null,
            List<string> outputParameters = null,
            bool? terrainShading = null,
            int? hours = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("start", start.ToString());
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            if (leadTime != null) parameters.Add("leadTime", leadTime.ToString());
            if (end != null) parameters.Add("end", end.ToString());
            if (duration != null) parameters.Add("duration", duration.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (tilt.HasValue) parameters.Add("tilt", tilt.Value.ToString());
            if (azimuth.HasValue) parameters.Add("azimuth", azimuth.Value.ToString());
            if (arrayType != null) parameters.Add("arrayType", arrayType.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.HistoricForecastRadiationAndWeather + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<HistoricForecastRadiationAndWeatherResponse>(rawContent);
                return new ApiResponse<HistoricForecastRadiationAndWeatherResponse>(data, rawContent);
            }
            return new ApiResponse<HistoricForecastRadiationAndWeatherResponse>(null, rawContent);
        }

        public async Task<ApiResponse<HistoricForecastPvPowerResponse>> GetRooftopPvPower(
            string start,
            double? latitude,
            double? longitude,
            float? capacity,
            string end = null,
            string duration = null,
            string timeZone = null,
            string period = null,
            float? tilt = null,
            float? azimuth = null,
            string installDate = null,
            float? lossFactor = null,
            int? hours = null,
            List<string> outputParameters = null,
            bool? terrainShading = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("start", start.ToString());
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            parameters.Add("capacity", capacity.ToString());
            if (end != null) parameters.Add("end", end.ToString());
            if (duration != null) parameters.Add("duration", duration.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (tilt.HasValue) parameters.Add("tilt", tilt.Value.ToString());
            if (azimuth.HasValue) parameters.Add("azimuth", azimuth.Value.ToString());
            if (installDate != null) parameters.Add("installDate", installDate.ToString());
            if (lossFactor.HasValue) parameters.Add("lossFactor", lossFactor.Value.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.HistoricForecastRooftopPvPower + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<HistoricForecastPvPowerResponse>(rawContent);
                return new ApiResponse<HistoricForecastPvPowerResponse>(data, rawContent);
            }
            return new ApiResponse<HistoricForecastPvPowerResponse>(null, rawContent);
        }
    }
}
