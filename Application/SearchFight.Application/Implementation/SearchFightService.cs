using SearchFight.Application.Interface;
using SearchFight.Domain;
using SearchFight.Domain.Contracts;
using SearchFight.Infrastructure.ReportService.Interface;
using SearchFight.Infrastructure.SearchEngineService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Application.Implementation
{
    public class SearchFightService : ISearchFightService
    {
        public List<string> Reports { get; set; }

        private ISearchFightDomainService _searchFightDomainService;
        private IReportService _reportService;
        private IEnumerable<ISearchEngineService> _searchEngineServices;

        public SearchFightService(ISearchFightDomainService searchFightDomainService, IReportService reportService, IEnumerable<ISearchEngineService> searchEngineServices)
        {
            _searchFightDomainService = searchFightDomainService;
            _reportService = reportService;
            _searchEngineServices = searchEngineServices;
        }

        public async Task ExecuteSearchFight(IEnumerable<string> args)
        {
            IEnumerable<SearchResult> searchResults = await GetSearchResultsAsync(args);
            IEnumerable<SearchResult> winnersBySearchEngine = GetWinnersBySearchEngine(searchResults);
            string totalWinner = GetTotalWinner(searchResults);

            Reports = _reportService.GenerateReports(searchResults, winnersBySearchEngine, totalWinner).ToList();
        }
       
        private async Task<IEnumerable<SearchResult>> GetSearchResultsAsync(IEnumerable<string> args)
        {
            List<SearchResult> searchResults = new List<SearchResult>();
            SearchResult searchResult;
            foreach (var searchEngine in _searchEngineServices)
            {
                foreach(var query in args)
                {
                    searchResult = new SearchResult(searchEngine.Name, query);
                    searchResult.ResultCount = await searchEngine.GetTotalResultsAsync(query);

                    searchResults.Add(searchResult);
                }
            }
            return searchResults;
        }
        private IEnumerable<SearchResult> GetWinnersBySearchEngine(IEnumerable<SearchResult> searchResults)
        {
            return _searchEngineServices
                .Select(searchEngine => new SearchResult(searchEngine.Name, _searchFightDomainService.GetSearchEngineWinner(searchEngine.Name, searchResults)));
        }
        private string GetTotalWinner(IEnumerable<SearchResult> searchResults)
        {
            return _searchFightDomainService.GetSearchResultWinner(searchResults);
        }
    }
}
