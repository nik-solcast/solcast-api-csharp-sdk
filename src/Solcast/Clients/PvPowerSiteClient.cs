
using Newtonsoft.Json;
using Solcast.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solcast.Clients
{
    public class PvPowerSiteClient
    {
        private readonly HttpClient _httpClient;

        public PvPowerSiteClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        public async Task<ApiResponse<string>> GetPvPowerSites(
    
        )
        {
            var parameters = new Dictionary<string, string>();

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.PvPowerSites + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();
            return new ApiResponse<string>(null, rawContent);
        }

        public async Task<ApiResponse<PvPowerResource>> GetPvPowerSite(
            string resourceid = null
        )
        {
            var parameters = new Dictionary<string, string>();
            if (resourceid != null) parameters.Add("resourceid", resourceid.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.PvPowerSite + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<PvPowerResource>(rawContent);
                return new ApiResponse<PvPowerResource>(data, rawContent);
            }
            return new ApiResponse<PvPowerResource>(null, rawContent);
        }

        public async Task<ApiResponse<PvPowerResource>> PostPvPowerSite(
            CreatePvPowerResource body
        )
        {
            var parameters = new Dictionary<string, string>();

            var jsonContent = JsonConvert.SerializeObject(body);
            var requestBody = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        
            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.PostAsync(SolcastUrls.PvPowerSite + $"?{queryString}", requestBody);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<PvPowerResource>(rawContent);
                return new ApiResponse<PvPowerResource>(data, rawContent);
            }
            return new ApiResponse<PvPowerResource>(null, rawContent);
        }

        public async Task<ApiResponse<PvPowerResource>> PutPvPowerSite(
            UpdatePvPowerResource body
        )
        {
            var parameters = new Dictionary<string, string>();

            var jsonContent = JsonConvert.SerializeObject(body);
            var requestBody = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        
            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.PutAsync(SolcastUrls.PvPowerSite + $"?{queryString}", requestBody);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<PvPowerResource>(rawContent);
                return new ApiResponse<PvPowerResource>(data, rawContent);
            }
            return new ApiResponse<PvPowerResource>(null, rawContent);
        }

        public async Task<ApiResponse<PvPowerResource>> PatchPvPowerSite(
            PatchPvPowerResource body
        )
        {
            var parameters = new Dictionary<string, string>();

            var jsonContent = JsonConvert.SerializeObject(body);
            var requestBody = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        
            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.PatchAsync(SolcastUrls.PvPowerSite + $"?{queryString}", requestBody);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<PvPowerResource>(rawContent);
                return new ApiResponse<PvPowerResource>(data, rawContent);
            }
            return new ApiResponse<PvPowerResource>(null, rawContent);
        }

        public async Task<ApiResponse<string>> DeletePvPowerSite(
            string resourceid = null
        )
        {
            var parameters = new Dictionary<string, string>();
            if (resourceid != null) parameters.Add("resourceid", resourceid.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.DeleteAsync(SolcastUrls.PvPowerSite + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();
            return new ApiResponse<string>(null, rawContent);
        }
    }
}
