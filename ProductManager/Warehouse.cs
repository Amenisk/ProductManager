using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    public class Warehouse
    {
        private Product[] products = new Product[] { new Product("Сыр", "Магнит", 150), new Product("Хлеб", "Пятёрочка", 50), 
            new Product("Молоко", "Верный", 40), new Product("Гречка", "Магнит", 100), new Product("Рис", "Верный", 120), new Product("Яблоки", "Пятёрочка", 80), 
            new Product("Картошка", "Магнит", 30), new Product("Огурцы", "Пятёрочка", 190), new Product("Колбаса", "Магнит", 200), new Product("Шоколад", "Верный", 60)};

        public Product GetProductByIndex(int index)
        {
            if(index < products.Length && index >= 0)
            {
                Console.WriteLine("Название: " + products[index].Name);
                Console.WriteLine("Стоимость: " + products[index].Price);
                Console.WriteLine("Магазин: " + products[index].ShopName);
                return products[index];
            }
            Console.WriteLine("Товара с таким индексом не существует");
            return null;
        }

        public Product GetProductByName(string name) 
        { 
            foreach(var p in products)
            {
                if(p.Name == name)
                {
                    Console.WriteLine("Название: " + p.Name);
                    Console.WriteLine("Стоимость: " + p.Price);
                    Console.WriteLine("Магазин: " + p.ShopName);
                    return p;
                }       
            }
            return null;
        }

        public Product[] SortProductsByName() 
        {
            Product temp;
            for (int i = 0; i < products.Length; i++)
            {
                for (int j = i + 1; j < products.Length; j++)
                {
                    if (products[i].Name.CompareTo(products[j].Name) > 0)
                    {
                        temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }
            return products;
        }
        public Product[] SortProductsByPrice()
        {
            Product temp;
            for (int i = 0; i < products.Length; i++)
            {
                for (int j = i + 1; j < products.Length; j++)
                {
                    if (products[i].Price > products[j].Price)
                    {
                        temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }
            return products;
        }
        public Product[] SortProductsByShopName()
        {
            Product temp;
            for (int i = 0; i < products.Length; i++)
            {
                for (int j = i + 1; j < products.Length; j++)
                {
                    if (products[i].ShopName.CompareTo(products[j].ShopName) > 0)
                    {
                        temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }
            return products;
        }

        public int SumProductsPrice(params Product[] product)
        {
            int price = 0;
            foreach(var p in product) 
            { 
                price += p.Price;
            }
            return price;
        }
    }
}
