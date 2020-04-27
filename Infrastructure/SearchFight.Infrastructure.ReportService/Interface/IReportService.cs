using SearchFight.Domain;
using System.Collections.Generic;

namespace SearchFight.Infrastructure.ReportService.Interface
{
    public interface IReportService
    {
        IEnumerable<string> GenerateReports(IEnumerable<SearchResult> searchResults, IEnumerable<SearchResult> winnersBySearchEngine, string totalWinner);
    }
}
