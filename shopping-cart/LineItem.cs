using static shopping_cart.Round;

namespace shopping_cart
{
    public class LineItem
    {
        public int Quantity { get; }

        public Product Product { get; }

        public LineItem(int quantity, Product product)
        {
            this.Quantity = quantity;
            Product = product;
        }

        public decimal TotalPrice()
        {
            return RoundHalfUp(Quantity * Product.UnitPrice);
        }
    }
}