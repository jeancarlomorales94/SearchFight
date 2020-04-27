using System.Text.Json.Serialization;

namespace SearchFight.Infrastructure.SearchEngineService.Configuration
{
    public class BingResponse
    {
        [JsonPropertyName("webPages")]
        public WebPages WebPages { get; set; }
    }
    public class WebPages
    {
        [JsonPropertyName("totalEstimatedMatches")]
        public long TotalEstimatedMatches { get; set; }
    }
}
