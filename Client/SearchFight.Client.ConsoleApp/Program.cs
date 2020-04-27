using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchFight.Application.Implementation;
using SearchFight.Application.Interface;
using SearchFight.Domain.Contracts;
using SearchFight.Domain.Services;
using SearchFight.Infrastructure.ReportService.Implementation;
using SearchFight.Infrastructure.ReportService.Interface;
using SearchFight.Infrastructure.SearchEngineService.Implementation;
using SearchFight.Infrastructure.SearchEngineService.Interface;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SearchFight.Client.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            await serviceProvider.GetService<App>().RunAsync(args);
        }
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var configuration = LoadConfiguration();
            services.AddSingleton(configuration);

            services.AddScoped<ISearchFightService, SearchFightService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ISearchFightDomainService, SearchFightDomainService>();
            services.AddScoped<ISearchEngineService, GoogleSearchEngine>();
            services.AddScoped<ISearchEngineService, BingSearchEngine>();
           
            services.AddTransient<App>();
            return services;
        }
        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
          
    }
}
