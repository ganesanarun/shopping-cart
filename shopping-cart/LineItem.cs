using static shopping_cart.Round;

namespace shopping_cart
{
    public class LineItem
    {
        public int Quantity { get; private set; }

        public Product Product { get; }

        public LineItem(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }

        public decimal TotalPrice()
        {
            return RoundHalfUp(Quantity * Product.UnitPrice);
        }

        public void Add(int quantity)
        {
            Quantity += quantity;
        }
    }
}