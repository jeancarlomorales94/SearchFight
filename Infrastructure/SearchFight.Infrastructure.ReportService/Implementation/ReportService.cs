using SearchFight.Domain;
using SearchFight.Infrastructure.ReportService.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Infrastructure.ReportService.Implementation
{
    public class ReportService : IReportService
    {
        public IEnumerable<string> GenerateReports(IEnumerable<SearchResult> searchResults, IEnumerable<SearchResult> winnersBySearchEngine, string totalWinner)
        {
            List<string> reports = new List<string>();
            reports.AddRange(GetSearchReport(searchResults));
            reports.AddRange(GetWinnersReport(winnersBySearchEngine));
            reports.Add(GetTotalWinnerReport(totalWinner));
            return reports;
        }

        private IEnumerable<string> GetSearchReport(IEnumerable<SearchResult> searchResults)
        {
            return searchResults.GroupBy(result => result.Query)
                .Select(group => $"{ group.Key }: { string.Join(" ", group.Select(x => $"{ x.SearchEngine }: { x.ResultCount }")) }");
        }
        private IEnumerable<string> GetWinnersReport(IEnumerable<SearchResult> winnersBySearchEngine)
        {
            return winnersBySearchEngine.Select(result => $"{result.SearchEngine} winner: {result.Query}");
        }
        private string GetTotalWinnerReport(string totalWinner)
        {
            return $"Total Winner: {totalWinner}";
        }

    }
}
