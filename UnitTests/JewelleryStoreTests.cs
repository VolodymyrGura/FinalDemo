using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinalDemo.Models;
using FinalDemo.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class JewelleryStoreTests
    {
        [TestMethod]
        public void CanCreateStoreWithDefaultCapacity()
        {
            var store = new JewelleryStore();

            Assert.IsNotNull(store);
            Assert.IsNotNull(store.Jewelleries);
            Assert.AreEqual(0, store.JewelleriesCount);
            Assert.AreEqual(4, store.Jewelleries.Capacity);
        }

        [TestMethod]
        public void CanCreateStoreWithSpecifiedCapacity()
        {
            const int capacity = 18;
            var store = new JewelleryStore(18);


            Assert.IsNotNull(store);
            Assert.IsNotNull(store.Jewelleries);
            Assert.AreEqual(0, store.JewelleriesCount);
            Assert.AreEqual(capacity, store.Jewelleries.Capacity);
        }

        [TestMethod]
        public void RandomValuesSetCorrectly()
        {
            var store = new JewelleryStore();
            store.Address = "Lviv";
            var random = new Random();
            const int count = 25;

            store.GetRandomJewelleries(count, random);

            Assert.IsNotNull(store);
            Assert.IsNotNull(store.Jewelleries);
            Assert.AreEqual("Lviv", store.Address);
            Assert.AreEqual(count, store.JewelleriesCount);

            foreach (var j in store.Jewelleries)
            {
                Assert.IsNotNull(j);
                Assert.IsFalse(string.IsNullOrEmpty(j.Title.ToString()));
                Assert.IsTrue(j.Price >= 1000 && j.Price < 20000);
            }
        }

        [TestMethod]
        public void GetSortedJewelleriesFromStoresTest()
        {
            List<string> list = new List<string>() { "Earrings", "Necklace", "WeddingRing", "Coulomb" };

            var query = from s in list
                        orderby s
                        select s;

           CollectionAssert.AreEqual(
               new[] { "Coulomb", "Earrings", "Necklace", "WeddingRing" }, query.ToList());
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
