using SearchFight.Infrastructure.SearchEngineService.Configuration;
using SearchFight.Infrastructure.SearchEngineService.Interface;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngineService.Implementation
{
    public class BingSearchEngine : ISearchEngineService
    {
        public string Name => "Bing";
        private HttpClient _httpClient = new HttpClient
        {
            DefaultRequestHeaders = {
                {
                    "Ocp-Apim-Subscription-Key",
                    ConfigurationManager.AppSettings["Bing.ApiKey"]
                }
            }
        };

        public async Task<long> GetTotalResultsAsync(string query)
        {
            string uri = ConfigurationManager.AppSettings["Bing.Uri"];
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
