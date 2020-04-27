using SearchFight.Domain;
using SearchFight.Domain.Contracts;
using SearchFight.Domain.Services;
using SearchFight.Test.Domain.Data;
using System.Collections.Generic;
using Xunit;

namespace SearchFight.Test.Domain
{
    public class SearchResultTest
    {
        private readonly ISearchFightDomainService _searchFightDomainService;

        public SearchResultTest()
        {
            _searchFightDomainService = new SearchFightDomainService();
        }

        [Theory]
        [ClassData(typeof(WinnerBySearchEngineData))]
        public void GetSearchEngineWinner_ReturnsWinnerBySearchEngine(string expectedQuery, string searchEngine, IEnumerable<SearchResult> searchResults)
        {
            string result = _searchFightDomainService.GetSearchEngineWinner(searchEngine, searchResults);
            Assert.Equal(expectedQuery, result);
        }

        [Theory]
        [ClassData(typeof(TotalWinnerData))]
        public void GetSearchResultWinner_ReturnsSearchFightWinner(string expectedQuery, IEnumerable<SearchResult> searchResults)
        {
            string result = _searchFightDomainService.GetSearchResultWinner(searchResults);
            Assert.Equal(expectedQuery, result);
        }


    }


}
