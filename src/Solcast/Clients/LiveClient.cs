
using Newtonsoft.Json;
using Solcast.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<ApiResponse<LiveResponse>> GetAdvancedPvPower(
            string resourceId,
            List<string> outputParameters = null,
            string period = null,
            int? hours = null,
            double? applyAvailability = null,
            double? applyConstraint = null,
            double? applyDustSoiling = null,
            double? applySnowSoiling = null,
            bool? applyTrackerInactive = null,
            bool? terrainShading = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("resourceId", resourceId.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (period != null) parameters.Add("period", period.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (applyAvailability.HasValue) parameters.Add("applyAvailability", applyAvailability.Value.ToString());
            if (applyConstraint.HasValue) parameters.Add("applyConstraint", applyConstraint.Value.ToString());
            if (applyDustSoiling.HasValue) parameters.Add("applyDustSoiling", applyDustSoiling.Value.ToString());
            if (applySnowSoiling.HasValue) parameters.Add("applySnowSoiling", applySnowSoiling.Value.ToString());
            if (applyTrackerInactive.HasValue) parameters.Add("applyTrackerInactive", applyTrackerInactive.Value.ToString());
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.LiveAdvancedPvPower + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<LiveResponse>(rawContent);
                return new ApiResponse<LiveResponse>(data, rawContent);
            }
            return new ApiResponse<LiveResponse>(null, rawContent);
        }

        public async Task<ApiResponse<LiveAggregationResponse>> GetAggregations(
            List<string> outputParameters = null,
            string collectionId = null,
            string aggregationId = null,
            int? hours = null,
            string period = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (collectionId != null) parameters.Add("collectionId", collectionId.ToString());
            if (aggregationId != null) parameters.Add("aggregationId", aggregationId.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.LiveAggregations + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<LiveAggregationResponse>(rawContent);
                return new ApiResponse<LiveAggregationResponse>(data, rawContent);
            }
            return new ApiResponse<LiveAggregationResponse>(null, rawContent);
        }

        public async Task<ApiResponse<LiveResponse>> GetRooftopPvPower(
            double? latitude,
            double? longitude,
            float? capacity,
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
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            parameters.Add("capacity", capacity.ToString());
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
            var response = await _httpClient.GetAsync(SolcastUrls.LiveRooftopPvPower + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<LiveResponse>(rawContent);
                return new ApiResponse<LiveResponse>(data, rawContent);
            }
            return new ApiResponse<LiveResponse>(null, rawContent);
        }

        public async Task<ApiResponse<LiveResponse>> GetRadiationAndWeather(
            double? latitude,
            double? longitude,
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
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (tilt.HasValue) parameters.Add("tilt", tilt.Value.ToString());
            if (azimuth.HasValue) parameters.Add("azimuth", azimuth.Value.ToString());
            if (arrayType != null) parameters.Add("arrayType", arrayType.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.LiveRadiationAndWeather + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<LiveResponse>(rawContent);
                return new ApiResponse<LiveResponse>(data, rawContent);
            }
            return new ApiResponse<LiveResponse>(null, rawContent);
        }
    }
}
