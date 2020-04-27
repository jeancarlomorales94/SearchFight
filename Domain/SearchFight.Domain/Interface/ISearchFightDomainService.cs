using System.Collections.Generic;

namespace SearchFight.Domain.Contracts
{
    public interface ISearchFightDomainService
    {
        string GetSearchEngineWinner(string searchEngine, IEnumerable<SearchResult> searchResults);
        string GetSearchResultWinner(IEnumerable<SearchResult> searchResults);
    }
}
