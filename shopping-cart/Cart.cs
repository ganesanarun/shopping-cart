using System.Collections.Generic;
using System.Linq;
using static shopping_cart.Round;

namespace shopping_cart
{
    public class Cart
    {
        private readonly decimal taxRate;
        private readonly Dictionary<Product, LineItem> items;

        public Cart()
        {
            items = new Dictionary<Product, LineItem>();
        }

        public Cart(double taxRate)
        {
            this.taxRate = (decimal) taxRate / 100;
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

        public Total TotalPrice()
        {
            var subTotal = items
                .Select(lineItem => lineItem.Value.TotalPrice())
                .Sum();
            var taxPrice = RoundHalfUp(Tax(taxRate, subTotal));
            return new Total(subTotal, taxPrice, RoundHalfUp(subTotal + taxPrice));
        }

        public int Quantity(in Product item)
        {
            return items.ContainsKey(item) ? items[item].Quantity : 0;
        }

        private static decimal Tax(decimal taxRate, decimal price)
        {
            return price * taxRate;
        }
    }
}