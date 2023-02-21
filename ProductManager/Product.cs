namespace ProductManager
{
    public class Product
    {
        public string Name { get; private set; }
        public string ShopName { get; private set; }

        public int Price { get; private set; }

        public Product(string name, string shopName, int price) 
        {
            Name = name;
            ShopName = shopName;
            Price = price;
        }
    }
}