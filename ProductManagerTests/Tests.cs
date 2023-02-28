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
        public void SortProductByName_returnCorrectArray()
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

        [TestMethod]
        public void SortProductByPrice_returnCorrectArray()
        {
            Warehouse warehouse = new Warehouse();
            Product[] testProducts = new Product[] { new Product("Картошка", "Магнит", 30), new Product("Молоко", "Верный", 40), new Product("Хлеб", "Пятёрочка", 50),
                new Product("Шоколад", "Верный", 60), new Product("Яблоки", "Пятёрочка", 80), new Product("Гречка", "Магнит", 100), new Product("Рис", "Верный", 120),
                new Product("Сыр", "Магнит", 150), new Product("Огурцы", "Пятёрочка", 190), new Product("Колбаса", "Магнит", 200)};

            Product[] products = warehouse.SortProductsByPrice();
            var js = new JavaScriptSerializer();

            Assert.AreEqual(js.Serialize(testProducts), js.Serialize(products));
        }

        [TestMethod]
        public void SortProductByShopName_returnCorrectArray()
        {
            Warehouse warehouse = new Warehouse();
            Product[] testProducts = new Product[] { new Product("Молоко", "Верный", 40), new Product("Рис", "Верный", 120), new Product("Шоколад", "Верный", 60),
                new Product("Сыр", "Магнит", 150), new Product("Картошка", "Магнит", 30), new Product("Колбаса", "Магнит", 200), new Product("Гречка", "Магнит", 100),
                new Product("Огурцы", "Пятёрочка", 190), new Product("Яблоки", "Пятёрочка", 80), new Product("Хлеб", "Пятёрочка", 50)};

            Product[] products = warehouse.SortProductsByShopName();
            var js = new JavaScriptSerializer();

            Assert.AreEqual(js.Serialize(testProducts), js.Serialize(products));
        }

        [TestMethod]
        public void SumProductsPrice_30and100_return130()
        {
            Warehouse warehouse = new Warehouse();
            var firstProduct = new Product("", "", 30);
            var secondProduct = new Product("", "", 100);
            var price = warehouse.SumProductsPrice(firstProduct, secondProduct);

            var testPrice = 130;

            Assert.AreEqual(testPrice, price);
        }

        [TestMethod]
        public void SumProductsPrice_nothing_return0()
        {
            Warehouse warehouse = new Warehouse();
            var price = warehouse.SumProductsPrice();

            var testPrice = 0;

            Assert.AreEqual(testPrice, price);
        }

        [TestMethod]
        public void SumProductsPrice_150and320and70and90and220_return850()
        {
            Warehouse warehouse = new Warehouse();
            var firstProduct = new Product("", "", 150);
            var secondProduct = new Product("", "", 320);
            var thirdProduct = new Product("", "", 70);
            var fourthProduct = new Product("", "", 90);
            var fifthProduct = new Product("", "", 220);
            var price = warehouse.SumProductsPrice(firstProduct, secondProduct, thirdProduct, fourthProduct, fifthProduct);

            var testPrice = 850;

            Assert.AreEqual(testPrice, price);
        }
    }
}
