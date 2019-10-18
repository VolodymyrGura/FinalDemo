using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalDemo.Models;
using FinalDemo.Processors;
using Xunit;

namespace UnitTests
{
	public class JewelleryStoreProcessorTests
	{
		[Fact]
		public void GetSortedJewelleriesFromStoresTest()
		{
			var store = new JewelleryStore();
			store.Address = "Lviv";
			var random = new Random();
			const int count = 25;

			store.GetRandomJewelleries(count, random);

			var result = new List<Jewellery>();
			result.AddRange(store.Jewelleries.OrderBy(j => j.Title));

			Assert.Equal(25, result.Count);
		}
	}
}
