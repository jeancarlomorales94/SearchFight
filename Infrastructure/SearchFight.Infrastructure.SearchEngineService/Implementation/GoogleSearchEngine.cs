using Microsoft.Extensions.Configuration;
using SearchFight.Infrastructure.SearchEngineService.Configuration;
using SearchFight.Infrastructure.SearchEngineService.Interface;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngineService.Implementation
{
    public class GoogleSearchEngine : ISearchEngineService
    {
        public string Name => "Google";
        private HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public GoogleSearchEngine(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<long> GetTotalResultsAsync(string query)
        {
            string uri = _configuration["SearchEngines:Google:Uri"];
            string apiKey = _configuration["SearchEngines:Google:ApiKey"];
            string searchEngineID = _configuration["SearchEngines:Google:SearchEngineID"];

            string request = uri.Replace("{API_KEY}", apiKey).Replace("{SEARCH_ENGINE_ID}", searchEngineID).Replace("{QUERY}", query);

            using (var response = await _httpClient.GetAsync(request))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(result);

                GoogleResponse googleResponse = JsonSerializer.Deserialize<GoogleResponse>(result);
                return Convert.ToInt64(googleResponse.SearchInformation.TotalResults);
            }
        }
    }
}
