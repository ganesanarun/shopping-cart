namespace shopping_cart
{
    public readonly struct Product
    {
        public Product(string brand, string name, decimal unitPrice)
        {
            this.brand = brand;
            this.name = name;
            UnitPrice = unitPrice;
        }

        private readonly string brand;

        private readonly string name;

        public decimal UnitPrice { get; }

        public string ProductId => brand + name;
    }
}