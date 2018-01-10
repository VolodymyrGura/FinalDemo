using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalDemo.Models;
using FinalDemo.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
	[TestClass]
	class JewelleryStoreProcessorTests
	{
		[TestMethod]
public void GetSortedJewelleriesFromStoresTest()
		{
			var store = new JewelleryStore();
			store.Address = "Lviv";
			var random = new Random();
			const int count = 25;

			store.GetRandomJewelleries(count, random);

			var result = new List<Jewellery>();
			result.AddRange(store.Jewelleries.OrderBy(j => j.Title));

			CollectionAssert.AreEqual(
			new[] { 106.7, 106.2, 105.2, 103.9 }, result);
		}
	}
}
