using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solcast.Clients
{
    public class AggregationClient
    {
        private readonly HttpClient _httpClient;

        public AggregationClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        public async Task<string> GetLiveAggregation(string collectionId, string aggregationId, string[] outputParameters = null, string format = "csv", Dictionary<string, string> additionalParameters = null)
        {
            var parameters = $"collection_id={collectionId}&aggregation_id={aggregationId}&format={format}";

            // Add output_parameters to the request if provided
            if (outputParameters != null && outputParameters.Length > 0)
            {
                parameters += $"&output_parameters={string.Join(",", outputParameters)}";
            }

            // Append additional parameters dynamically
            if (additionalParameters != null)
            {
                parameters += "&" + string.Join("&", additionalParameters.Select(p => $"{p.Key}={p.Value}"));
            }

            var response = await _httpClient.GetAsync($"{SolcastUrls.LiveGridAggregations}?{parameters}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetForecastAggregation(string collectionId, string aggregationId, string[] outputParameters = null, string format = "csv", Dictionary<string, string> additionalParameters = null)
        {
            var parameters = $"collection_id={collectionId}&aggregation_id={aggregationId}&format={format}";

            // Add output_parameters to the request if provided
            if (outputParameters != null && outputParameters.Length > 0)
            {
                parameters += $"&output_parameters={string.Join(",", outputParameters)}";
            }

            // Append additional parameters dynamically
            if (additionalParameters != null)
            {
                parameters += "&" + string.Join("&", additionalParameters.Select(p => $"{p.Key}={p.Value}"));
            }

            var response = await _httpClient.GetAsync($"{SolcastUrls.ForecastGridAggregations}?{parameters}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
