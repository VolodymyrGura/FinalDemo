namespace FinalDemo
{
    using System;
    using System.Configuration;
    using Processors;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = GetServices();
            var configuration = GetConfiguration();
            
            Console.WriteLine("Working...");

            var inputFile = configuration.GetValue<string>("InputTextFile");
            var countFile = configuration.GetValue<string>("Count");
            var sortFile = configuration.GetValue<string>("Sort");
            var outputJson = configuration.GetValue<string>("OutputJsonFile");

            var logger = container.GetService<ILoggerFactory>().AddLog4Net()
                .CreateLogger<Program>();
            
            var manager = new ApplicationManager(configuration, logger);
            manager.WriteIntoFile(inputFile, sortFile);
            manager.WriteIntoFileCount(inputFile, countFile);
            manager.SerializeInfo(inputFile, outputJson);

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static IServiceProvider GetServices()
        {
            var services = new ServiceCollection();

            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Warning));

            return services.BuildServiceProvider();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json", true, true);

            return builder.Build();
        }
    }
}
