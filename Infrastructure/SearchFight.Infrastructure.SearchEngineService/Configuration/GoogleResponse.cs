using System.Text.Json.Serialization;

namespace SearchFight.Infrastructure.SearchEngineService.Configuration
{
    public class GoogleResponse
    {
        [JsonPropertyName("searchInformation")]
        public SearchInformation SearchInformation { get; set; }
    }
    public class SearchInformation
    {
        [JsonPropertyName("totalResults")]

        public string TotalResults { get; set; }
    }
}
