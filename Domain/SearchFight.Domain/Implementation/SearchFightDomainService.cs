using SearchFight.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Domain.Services
{
    public class SearchFightDomainService : ISearchFightDomainService
    {
        public string GetSearchEngineWinner(string searchEngine, IEnumerable<SearchResult> searchResults)
        {
            return searchResults.Where(result => result.SearchEngine == searchEngine).OrderByDescending(result => result.ResultCount).First().Query;
        }
        public string GetSearchResultWinner(IEnumerable<SearchResult> searchResults)
        {
            var groupedResultsByQuery = searchResults.GroupBy(result => new { result.Query, result.ResultCount });
            var winner = groupedResultsByQuery.Aggregate((result, nextResult) => result.Key.ResultCount > nextResult.Key.ResultCount ? result : nextResult);
            return winner.Key.Query;
        }

    }
}
