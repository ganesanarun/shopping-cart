namespace shopping_cart
{
    public readonly struct Total
    {
        public decimal SubTotal { get; }
        public decimal SalesTax { get; }
        public decimal TotalPrice { get; }

        public Total(decimal subTotal, decimal salesTax, decimal totalPrice)
        {
            SubTotal = subTotal;
            SalesTax = salesTax;
            TotalPrice = totalPrice;
        }
    }
}