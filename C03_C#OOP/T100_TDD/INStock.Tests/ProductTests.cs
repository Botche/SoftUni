namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        private const string productLabelName = "Eggs";
        private const decimal productPrice = 1.5m;
        private const int quantity = 2;

        private Product product;

        [SetUp]
        public void Setup()
        {
            product = new Product(productLabelName, productPrice,quantity);
        }

        [Test]
        public void TestProductConstructor()
        {
            Assert.AreEqual(productLabelName, product.Label);
            Assert.AreEqual(productPrice, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [Test]
        public void TestValidationOfLabelWithNull()
        {
            Assert.Throws<ArgumentException>(
                () => new Product(null, productPrice,quantity));
        }

        [Test]
        public void TestValidationOfLabelWithEmptyString()
        {
            Assert.Throws<ArgumentException>(
                () => new Product("", productPrice, quantity));
        }

        [Test]
        public void TestValidationOfPriceWithZeroPrice()
        {
            Assert.Throws<ArgumentException>(
                () => new Product(productLabelName, 0, quantity));
        }

        [Test]
        public void TestValidationOfPriceWithNegativePrice()
        {
            Assert.Throws<ArgumentException>(
                () => new Product(productLabelName, -1, quantity));
        }

        [Test]
        public void TestValidationOfQuantityWithNegativeQuantity()
        {
            Assert.Throws<ArgumentException>(
                () => new Product(productLabelName, productPrice, -2));
        }

        [Test]
        public void TestCompareTo()
        {
            int expectedResult = 0;
            var otherProduct = new Product("Eggs", 2.5m, 1);

            Assert.AreEqual(expectedResult, product.CompareTo(otherProduct));
        }
    }
}