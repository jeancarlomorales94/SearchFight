using Microsoft.Extensions.Configuration;
using SearchFight.Infrastructure.SearchEngineService.Configuration;
using SearchFight.Infrastructure.SearchEngineService.Interface;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngineService.Implementation
{
    public class BingSearchEngine : ISearchEngineService
    {
        public string Name => "Bing";
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public BingSearchEngine(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                DefaultRequestHeaders = {
                {
                    "Ocp-Apim-Subscription-Key",
                    _configuration["SearchEngines:Bing:ApiKey"]
                }
            }};
        }

        public async Task<long> GetTotalResultsAsync(string query)
        {
            string uri = _configuration["SearchEngines:Bing:Uri"];
            string request = uri.Replace("{QUERY}", query);
            using (var response = await _httpClient.GetAsync(request))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(result);

                BingResponse bingResponse = JsonSerializer.Deserialize<BingResponse>(result);
                return bingResponse.WebPages.TotalEstimatedMatches;
            }
        }
    }
}
