namespace SearchFight.Domain
{
    public class SearchResult
    {
        public string SearchEngine { get; private set; }
        public string Query { get; private set; }
        public long ResultCount { get; set; }

        public SearchResult(string searchEngine, string query, long resultCount = 0)
        {
            this.SearchEngine = searchEngine;
            this.Query = query;
            this.ResultCount = resultCount;
        }
        
    }
}
