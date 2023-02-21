using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager;
using System;
using System.Web.Script.Serialization;

namespace ProductManagerTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetProductByIndex_0_returnProduct()
        {
            Warehouse warehouse = new Warehouse();
            Product testProduct = new Product("Сыр", "Магнит", 150);

            Product p = warehouse.GetProductByIndex(0);
            var js = new JavaScriptSerializer();

            Assert.AreEqual(js.Serialize(testProduct), js.Serialize(p));
        }

        [TestMethod]
        public void GetProductByIndex_9_returnProduct()
        {
            Warehouse warehouse = new Warehouse();
            Product testProduct = new Product("Шоколад", "Верный", 60);

            Product p = warehouse.GetProductByIndex(9);
            var js = new JavaScriptSerializer();

            Assert.AreEqual(js.Serialize(testProduct), js.Serialize(p));
        }

        [TestMethod]
        public void GetProductByIndex_minus1_returnProduct()
        {
            Warehouse warehouse = new Warehouse();

            Product p = warehouse.GetProductByIndex(-1);

            Assert.AreEqual(null, p);
        }

        [TestMethod]
        public void GetProductByIndex_10_returnProduct()
        {
            Warehouse warehouse = new Warehouse();

            Product p = warehouse.GetProductByIndex(10);

            Assert.AreEqual(null, p);
        }

        [TestMethod]
        public void GetProductByName_Гречка_returnProduct()
        {
            Warehouse warehouse = new Warehouse();
            Product testProduct = new Product("Гречка", "Магнит", 100);

            Product p = warehouse.GetProductByName("Гречка");
            var js = new JavaScriptSerializer();

            Assert.AreEqual(js.Serialize(testProduct), js.Serialize(p));
        }

        [TestMethod]
        public void GetProductByName_варпщт_returnNull()
        {
            Warehouse warehouse = new Warehouse();

            Product p = warehouse.GetProductByName("варпщт");

            Assert.AreEqual(null, p);
        }

        [TestMethod]
        public void GetProductByName_Carrot_returnNull()
        {
            Warehouse warehouse = new Warehouse();

            Product p = warehouse.GetProductByName("Carrot");

            Assert.AreEqual(null, p);
        }

        [TestMethod]
        public void SortProductByName_Carrot_returnProduct()
        {
            Warehouse warehouse = new Warehouse();
            Product[] testProducts = new Product[] { new Product("Гречка", "Магнит", 100), new Product("Картошка", "Магнит", 30), 
                new Product("Колбаса", "Магнит", 200), new Product("Молоко", "Верный", 40), new Product("Огурцы", "Пятёрочка", 190), 
                new Product("Рис", "Верный", 120), new Product("Сыр", "Магнит", 150), new Product("Хлеб", "Пятёрочка", 50), 
                new Product("Шоколад", "Верный", 60), new Product("Яблоки", "Пятёрочка", 80)};

            Product[] products = warehouse.SortProductsByName();
            var js = new JavaScriptSerializer();

            Assert.AreEqual(js.Serialize(testProducts), js.Serialize(products));
        }
    }
}
