using System;
using FinalDemo.Models;
using Moq;
using Xunit;

namespace UnitTests
{
    public class JewelleryTests
    {
        [Fact]
        public void RandomValuesSetCorrectly()
        {
            var jewellery = new Jewellery();
            var random = new Random();

            var mock = new Mock<Random>();
            mock.Setup(n => n.Next()).Returns(1);

            jewellery.GetRandomValues(random);
            var price = jewellery.Price;

            Assert.NotNull(jewellery);
            Assert.False(string.IsNullOrEmpty(jewellery.Title.ToString()));
            Assert.True(price >= 1000 && price < 20000);
        }
    }
}
