using FluentAssertions;
using shopping_cart;
using Xunit;

namespace Shopping_cart.Tests
{
    public class LineItemTests
    {
        [Fact]
        public void TotalPriceAlways2Decimals()
        {
            var doveSoap = new Product("Dove", "Soap", 39.99899m);
            var fiveDoveSoaps = new LineItem(5, doveSoap);

            fiveDoveSoaps.TotalPrice().Should().Be(199.99M);
        }
    }
}