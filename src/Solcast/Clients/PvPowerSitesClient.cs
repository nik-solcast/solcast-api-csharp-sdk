using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solcast.Clients
{
    public class PvPowerSitesClient
    {
        private readonly HttpClient _httpClient;

        public PvPowerSitesClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }

        public async Task<string> ListPvPowerSites(string format = "json")
        {
            var parameters = $"format={format}";
            var response = await _httpClient.GetAsync($"{SolcastUrls.PvPowerSites}?{parameters}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPvPowerSite(string resourceId, string format = "json")
        {
            var parameters = $"resource_id={resourceId}&format={format}";
            var response = await _httpClient.GetAsync($"{SolcastUrls.PvPowerSite}?{parameters}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> CreatePvPowerSite(string name, double latitude, double longitude, string format = "json", string capacity = null)
        {
            var parameters = $"name={name}&latitude={latitude}&longitude={longitude}&format={format}";
            if (capacity != null)
            {
                parameters += $"&capacity={capacity}";
            }
            var content = new StringContent(parameters);
            var response = await _httpClient.PostAsync(SolcastUrls.PvPowerSite, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PatchPvPowerSite(string resourceId, string parameters)
        {
            var content = new StringContent(parameters);
            var response = await _httpClient.PatchAsync($"{SolcastUrls.PvPowerSite}/{resourceId}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdatePvPowerSite(string resourceId, string parameters)
        {
            var content = new StringContent(parameters);
            var response = await _httpClient.PutAsync($"{SolcastUrls.PvPowerSite}/{resourceId}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeletePvPowerSite(string resourceId)
        {
            var response = await _httpClient.DeleteAsync($"{SolcastUrls.PvPowerSite}/{resourceId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
