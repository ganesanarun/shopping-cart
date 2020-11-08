using FluentAssertions;
using shopping_cart;
using Xunit;

namespace Shopping_cart.Tests
{
    public class CartTests
    {
        [Fact]
        public void AddItemsToTheEmptyCart()
        {
            var cart = new Cart();
            var doveSoap = new Product("Dove", "Soap", 39.99m);
            var fiveDoveSoaps = new LineItem(5, doveSoap);

            cart.AddItem(fiveDoveSoaps);

            cart.Quantity(doveSoap).Should().Be(5);
            cart.TotalPrice().Should().Be(199.95m);
        }

        [Fact]
        public void AddAlreadyExistingItemIntoTheNonEmptyCart()
        {
            var cart = new Cart();
            var doveSoap = new Product("Dove", "Soap", 39.99m);
            var fiveDoveSoaps = new LineItem(5, doveSoap);
            cart.AddItem(fiveDoveSoaps);
            
            cart.AddItem(new LineItem(3, doveSoap));

            cart.Quantity(doveSoap).Should().Be(8);
            cart.TotalPrice().Should().Be(319.92m);
        }
        
        [Fact]
        public void EmptyCart()
        {
            var cart = new Cart();
            var doveSoap = new Product("Dove", "Soap", 39.99m);
            
            cart.Quantity(doveSoap).Should().Be(0);
        }
    }
}