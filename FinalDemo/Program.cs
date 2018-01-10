namespace FinalDemo
{
    using System;
    using System.Configuration;
    using Processors;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Working...");

            var inputFile = ConfigurationManager.AppSettings["InputTextFile"];
            var countFile = ConfigurationManager.AppSettings["Count"];
            var sortFile = ConfigurationManager.AppSettings["Sort"];
            var outputJson = ConfigurationManager.AppSettings["OutputJsonFile"];

            var manager = new ApplicationManager();
            manager.WriteIntoFile(inputFile, sortFile);
            manager.WriteIntoFileCount(inputFile, countFile);
            manager.SerializeInfo(inputFile, outputJson);

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
