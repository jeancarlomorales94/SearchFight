using SearchFight.Application.Implementation;
using SearchFight.Application.Interface;
using System;
using System.Threading.Tasks;

namespace SearchFight.Client.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No valid arguments have been passed.");
                return;
            }

            Console.WriteLine("Loading results...");
         
            ISearchFightService searchFightService = new SearchFightService();
            await searchFightService.ExecuteSearchFight(args);
            searchFightService.Reports.ForEach(report => Console.WriteLine(report));
           
            Console.ReadLine();
        }
    }
}
