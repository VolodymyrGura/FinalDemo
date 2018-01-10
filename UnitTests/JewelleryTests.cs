using System;
using FinalDemo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class JewelleryTests
    {
        [TestMethod]
        public void RandomValuesSetCorrectly()
        {
            var jewellery = new Jewellery();
            var random = new Random();

            var mock = new Mock<Random>();
            mock.Setup(n => n.Next()).Returns(1);

            jewellery.GetRandomValues(random);
            var price = jewellery.Price;

            Assert.IsNotNull(jewellery);
            Assert.IsFalse(string.IsNullOrEmpty(jewellery.Title.ToString()));
            Assert.IsTrue(price >= 1000 && price < 20000);
        }
    }
}
