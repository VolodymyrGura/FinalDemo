namespace FinalDemo.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Microsoft.Extensions.Logging;

    public class JewelleryStoreProcessor
    {
        private readonly ILogger _logger;

        public JewelleryStoreProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public List<MetalCountPair> GetAllMetalsCountDistinct(JewelleryStore store)
        {
            if (store == null)
            {
                _logger.LogError($"Invalid argument: {nameof(store)}");
                throw new ArgumentNullException(nameof(store));
            }

            var query = from j in store.Jewelleries
                group j by j.Metal
                into gr
                select new MetalCountPair { Name = gr.Key.ToString(), Count = gr.Count() };

            return query.ToList();
        }

        public List<Jewellery> GetSortedJewelleriesFromStores(JewelleryStore store, int jewelleriesCount)
        {
            if (store == null)
            {
                _logger.LogError($"Invalid argument: {nameof(store)}");
                throw new ArgumentNullException(nameof(store));
            }

            var result = new List<Jewellery>();
            if (store.JewelleriesCount > jewelleriesCount)
            {
                result.AddRange(store.Jewelleries.OrderBy(j => j.Title));
            }

            return result;
        }

        public class MetalCountPair
        {
            public string Name { get; set; }

            public int Count { get; set; }

            public override string ToString()
            {
                var result = $"Name: {this.Name}\tCount: {this.Count}\n";
                return result;
            }
        }
    }
}
