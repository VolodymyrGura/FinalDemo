using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinalDemo.Models;
using FinalDemo.Processors;
using Xunit;

namespace UnitTests
{
    public class JewelleryStoreTests
    {
        [Fact]
        public void CanCreateStoreWithDefaultCapacity()
        {
            var store = new JewelleryStore();

            Assert.NotNull(store);
            Assert.NotNull(store.Jewelleries);
            Assert.Equal(0, store.JewelleriesCount);
            Assert.Equal(4, store.Jewelleries.Capacity);
        }

        [Fact]
        public void CanCreateStoreWithSpecifiedCapacity()
        {
            const int capacity = 18;
            var store = new JewelleryStore(18);


            Assert.NotNull(store);
            Assert.NotNull(store.Jewelleries);
            Assert.Equal(0, store.JewelleriesCount);
            Assert.Equal(capacity, store.Jewelleries.Capacity);
        }

        [Fact]
        public void RandomValuesSetCorrectly()
        {
            var store = new JewelleryStore();
            store.Address = "Lviv";
            var random = new Random();
            const int count = 25;

            store.GetRandomJewelleries(count, random);

            Assert.NotNull(store);
            Assert.NotNull(store.Jewelleries);
            Assert.Equal("Lviv", store.Address);
            Assert.Equal(count, store.JewelleriesCount);

            foreach (var j in store.Jewelleries)
            {
                Assert.NotNull(j);
                Assert.False(string.IsNullOrEmpty(j.Title.ToString()));
                Assert.True(j.Price >= 1000 && j.Price < 20000);
            }
        }

        [Fact]
        public void GetSortedJewelleriesFromStoresTest()
        {
            List<string> list = new List<string>() { "Earrings", "Necklace", "WeddingRing", "Coulomb" };

            var query = from s in list
                        orderby s
                        select s;

            var result = query.ToList();

            Assert.Collection(result, s => s.Contains("Coulomb"), s => s.Contains("Earrings"), s => s.Contains("Necklace"), s => s.Contains("WeddingRing"));
        }

  //      [TestMethod] //TODO
  //      public void CanCreateMetalCountPairTest()
  //      {
  //          var storeReader = new JewelleryStoreReader("test.txt");
  //          var storeProcessor = new JewelleryStoreProcessor();
  //          var stores = storeReader.ReadStores();
  //          foreach (var store in stores)
  //          {
  //              var expected = storeProcessor.GetAllMetalsCountDistinct(store);
  //          }
		//}

        public class FakeRandom : Random
        {
            public override int Next()
            {
                return 1;
            }
        }
    }
}
