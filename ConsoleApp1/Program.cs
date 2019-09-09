using System;
using Microsoft.Extensions.DependencyInjection;
using ReferenceIntegration;
using Microsoft.Extensions.Caching.Memory;

namespace ConsoleApp1
{
    class Program
    {
        private static IServiceProvider serviceProvider = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SetUpDependencyInjection();

            CallRegionFinder();
        }

        private static void SetUpDependencyInjection()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IReadOnlyRepository<Coverage>, CoverageRepository>();
            serviceCollection.AddScoped<IReadOnlyRepository<Region>, RegionRepository>();
            serviceCollection.AddScoped<CoverageRepository>();
            //serviceCollection.AddScoped<IReadOnlyRepository<Region>, RegionRepository>();

            serviceProvider = serviceCollection.AddMemoryCache().BuildServiceProvider();
            CachedRepositoryDecorator<Coverage>._cache = serviceProvider.GetService<IMemoryCache>();
        }


        private static void CallRegionFinder()
        {
            var serviceRegion = serviceProvider.GetService<IReadOnlyRepository<Coverage>>();
            var r = serviceRegion.Find("1");
            Console.WriteLine(r.Des + "<<<");
            System.Threading.Thread.Sleep(1000);

            r = serviceRegion.Find("1");
            Console.WriteLine(r.Des + "<<<");

            //
            var serviceRegion1 = serviceProvider.GetService<CoverageRepository>();
            var r1 = serviceRegion1.Find("2");

            CoverageRepository cr = new CoverageRepository();
            cr.Find("3");
        }
    }
}
