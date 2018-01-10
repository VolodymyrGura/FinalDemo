namespace FinalDemo.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class JewelleryStoreProcessor
    {
        public List<MetalCountPair> GetAllMetalsCountDistinct(JewelleryStore store)
        {
            Logger.InitLogger();
            if (store == null)
            {
                Logger.Log.Error($"Invalid argument: {nameof(store)}");
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
            Logger.InitLogger();
            if (store == null)
            {
                Logger.Log.Error($"Invalid argument: {nameof(store)}");
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
