using SearchFight.Application.Interface;
using System;
using System.Threading.Tasks;

namespace SearchFight.Client.ConsoleApp
{
    public class App
    {
        private readonly ISearchFightService _searchFightService;
        public App(ISearchFightService searchFightService)
        {
            _searchFightService = searchFightService;
        }
        public async Task RunAsync(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No valid arguments have been passed.");
                return;
            }

            Console.WriteLine("Loading results...");
            await _searchFightService.ExecuteSearchFight(args);
            _searchFightService.Reports.ForEach(report => Console.WriteLine(report));

            Console.ReadLine();
        }
    }
}
