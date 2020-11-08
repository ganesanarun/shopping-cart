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
            cart.TotalPrice().TotalPrice.Should().Be(199.95m);
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
            cart.TotalPrice().TotalPrice.Should().Be(319.92m);
            cart.TotalPrice().SubTotal.Should().Be(319.92m);
            cart.TotalPrice().SalesTax.Should().Be(0m);
        }
        
        [Fact]
        public void AddMoreThanOneProductIntoTheCart()
        {
            var cart = new Cart(12.5);
            var doveSoap = new Product("Dove", "Soap", 39.99m);
            var axeDeo = new Product("Axe", "Deo", 99.99m);
            var twoDoveSoaps = new LineItem(2, doveSoap);
            var twoAxeDeo = new LineItem(2, axeDeo);

            cart.AddItem(twoDoveSoaps);
            cart.AddItem(twoAxeDeo);

            cart.Quantity(doveSoap).Should().Be(2);
            cart.Quantity(axeDeo).Should().Be(2);
            cart.TotalPrice().TotalPrice.Should().Be(314.96m);
            cart.TotalPrice().SalesTax.Should().Be(35.00m);
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