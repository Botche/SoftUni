namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;
        private const string make= "Huawei";
        private const string model = "P20";

        [SetUp]
        public void SetUp()
        {
            phone = new Phone(make, model);
        }

        [Test]
        public void TestConstructor()
        {
            var expectedMake = "Huawei";
            var expectedModel = "P20";
            var expectedCount = 0;

            Assert.AreEqual(expectedMake,phone.Make);
            Assert.AreEqual(expectedModel, phone.Model);
            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestMakeValidationWithNullString()
        {
            Assert.Throws<ArgumentException>(
                () => new Phone(null, model));
        }

        [Test]
        public void TestModelValidationWithNullString()
        {
            Assert.Throws<ArgumentException>(
                () => new Phone(make, ""));
        }

        [Test]
        public void TestAddContact()
        {
            phone.AddContact("Ivan", "123");

            Assert.AreEqual($"Calling Ivan - 123...",phone.Call("Ivan"));
        }

        [Test]
        public void AddExistingContact()
        {
            phone.AddContact("Ivan", "123");

            Assert.Throws<InvalidOperationException>(
                () => phone.AddContact("Ivan", "123"));
        }

        [Test]
        public void TestCallNotExistingContact()
        {
            Assert.Throws<InvalidOperationException>(
                () => phone.Call("Ivan"));
        }

        [Test]
        public void TestCount()
        {
            var expectedCount = 1;

            phone.AddContact("Ivan", "123");

            Assert.AreEqual(expectedCount, phone.Count);
        }
    }
}