using System.Collections.Generic;
using System.Linq;
using static shopping_cart.Round;

namespace shopping_cart
{
    public class Cart
    {
        private readonly Dictionary<Product, LineItem> items;

        public Cart()
        {
            items = new Dictionary<Product, LineItem>();
        }

        public void AddItem(LineItem item)
        {
            if (!items.ContainsKey(item.Product))
            {
                items.Add(item.Product, item);
                return;
            }

            items[item.Product].Add(item.Quantity);
        }

        public decimal TotalPrice()
        {
            var totalPrice = items
                .Select(lineItem => lineItem.Value.TotalPrice())
                .Sum();
            return RoundHalfUp(totalPrice);
        }

        public int Quantity(in Product item)
        {
            return items.ContainsKey(item) ? items[item].Quantity : 0;
        }
    }
}