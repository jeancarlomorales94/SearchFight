using SearchFight.Infrastructure.SearchEngineService.Configuration;
using SearchFight.Infrastructure.SearchEngineService.Interface;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngineService.Implementation
{
    public class GoogleSearchEngine : ISearchEngineService
    {
        public string Name => "Google";
        private HttpClient _httpClient = new HttpClient();

        public async Task<long> GetTotalResultsAsync(string query)
        {
            string uri = ConfigurationManager.AppSettings["Google.Uri"];
            string apiKey = ConfigurationManager.AppSettings["Google.ApiKey"];
            string searchEngineID = ConfigurationManager.AppSettings["Google.SearchEngineID"];

            string request = uri.Replace("{API_KEY}", apiKey).Replace("{SEARCH_ENGINE_ID}", searchEngineID).Replace("{QUERY}", query);

            using (var response = await _httpClient.GetAsync(request))
            {
                var result = await response.Content.ReadAsStringAsync();
                GoogleResponse googleResponse = JsonSerializer.Deserialize<GoogleResponse>(result);
                return Convert.ToInt64(googleResponse.SearchInformation.TotalResults);
            }
        }
    }
}
