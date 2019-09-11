namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;
    using System;

    public class ProductStockTests
    {
        private const string productLabelName = "Eggs";
        private const decimal productPrice = 1.5m;
        private const int quantity = 2;

        private Product product;
        private ProductStock productStock;

        [SetUp]
        public void Setup()
        {
            product = new Product(productLabelName, productPrice, quantity);
            productStock = new ProductStock();
        }

        [Test]
        public void TestConstructors()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, productStock.Count);
        }

        [Test]
        public void TestAddMethod()
        {
            int expectedCount = 1;

            productStock.Add(product);

            Assert.AreEqual(expectedCount, productStock.Count);
        }

        [Test]
        public void TestContainsMethod()
        {
            var expectedResult = true;

            productStock.Add(product);

            Assert.AreEqual(expectedResult, productStock.Contains(product));
        }

        [Test]
        public void TestContainsMethodWithExpectedResultFalse()
        {
            var expectedResult = false;

            Assert.AreEqual(expectedResult, productStock.Contains(product));
        }

        [Test]
        public void TestFindMethod()
        {
            var expectedResult = product;

            productStock.Add(product);

            Assert.AreEqual(product, productStock.Find(1));
        }

        [Test]
        public void TestFindMethodWithBadData()
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(1));
        }

        [Test]
        public void TestFindByLabel()
        {
            var expectedResult = product;

            productStock.Add(product);

            Assert.AreEqual(expectedResult, productStock.FindByLabel(productLabelName));
        }

        [Test]
        public void TestFindByLabelWithBadData()
        {
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel(productLabelName));
        }

        [Test]
        public void TestFindMostExpensiveOne()
        {
            var expectedResult = 1.5m;

            productStock.Add(product);
            product = new Product("Milk", 1.2m, 3);
            productStock.Add(product);

            Assert.AreEqual(expectedResult, productStock.FindMostExpensiveProduct().Price);
        }

        [Test]
        public void TestRemove()
        {
            var expectedResult = true;

            productStock.Add(product);

            Assert.AreEqual(expectedResult, productStock.Remove(product));
        }

        [Test]
        public void TestRemoveWithBadData()
        {
            var expectedResult = false;

            Assert.AreEqual(expectedResult, productStock.Remove(product));
        }

        [Test]
        public void TestIndexer()
        {
            productStock.Add(product);
            productStock.Add(product);

            product = new Product("Milk", 1.2m, 3);

            productStock[0] = product;

            Assert.AreEqual(product, productStock[0]);
        }
    }
}
