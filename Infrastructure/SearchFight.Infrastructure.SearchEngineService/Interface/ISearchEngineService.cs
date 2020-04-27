using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngineService.Interface
{
    public interface ISearchEngineService
    {
        string Name { get; }
        Task<long> GetTotalResultsAsync(string query);
    }
}
