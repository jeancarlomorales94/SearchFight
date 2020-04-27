using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.Application.Interface
{
    public interface ISearchFightService
    {
        Task ExecuteSearchFight(IEnumerable<string> args);
        List<string> Reports { get; set; }
    }
}
