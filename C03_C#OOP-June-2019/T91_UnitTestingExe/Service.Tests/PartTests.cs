using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        private const bool isBroken = true;

        private const string laptopPartName = "RamCard";
        private const decimal laptopPartCost = 10m;

        private const string pcPartName = "Monitor";
        private const decimal pcPartCost = 5m;

        private const string phonePartName = "Display";
        private const decimal phonePartCost = 25m;

        private Part laptopPart;
        private Part pcPart;
        private Part phonePart;

        [SetUp]
        public void Setup()
        {
            laptopPart = new LaptopPart(laptopPartName, laptopPartCost, isBroken);
            pcPart = new PCPart(pcPartName, pcPartCost, isBroken);
            phonePart = new PhonePart(phonePartName, phonePartCost, isBroken);
        }

        [Test]
        public void TestLaptopConstructorWithoutIsBrokenParameter()
        {
            laptopPart = new LaptopPart(laptopPartName, laptopPartCost);

            var expectedPartCost = laptopPartCost * 1.5m;

            Assert.AreEqual(laptopPartName, laptopPart.Name);
            Assert.AreEqual(expectedPartCost, laptopPart.Cost);
            Assert.AreEqual(false, laptopPart.IsBroken);
        }

        [Test]
        public void TestLaptopConstructorWithIsBrokenParameter()
        {
            var expectedPartCost = laptopPartCost * 1.5m;

            Assert.AreEqual(laptopPartName, laptopPart.Name) ;
            Assert.AreEqual(expectedPartCost, laptopPart.Cost) ;
            Assert.AreEqual(isBroken, laptopPart.IsBroken) ;
        }

        [Test]
        public void TestPcConstructorWithoutIsBrokenParameter()
        {
            pcPart = new PCPart(pcPartName, pcPartCost);

            var expectedPartCost = pcPartCost * 1.2m;

            Assert.AreEqual(pcPartName, pcPart.Name);
            Assert.AreEqual(expectedPartCost, pcPart.Cost);
            Assert.AreEqual(false, pcPart.IsBroken);
        }

        [Test]
        public void TestPcConstructorWithIsBrokenParameter()
        {
            var expectedPartCost = pcPartCost * 1.2m;

            Assert.AreEqual(pcPartName, pcPart.Name) ;
            Assert.AreEqual(expectedPartCost, pcPart.Cost) ;
            Assert.AreEqual(isBroken, pcPart.IsBroken) ;
        }

        [Test]
        public void TestPhoneConstructorWithoutIsBrokenParameter()
        {
            phonePart = new PhonePart(phonePartName, phonePartCost);

            var expectedPartCost = phonePartCost * 1.3m;

            Assert.AreEqual(phonePartName, phonePart.Name);
            Assert.AreEqual(expectedPartCost, phonePart.Cost);
            Assert.AreEqual(false, phonePart.IsBroken);
        }

        [Test]
        public void TestPhoneConstructorWithIsBrokenParameter()
        {
            var expectedPartCost = phonePartCost * 1.3m;

            Assert.AreEqual(phonePartName, phonePart.Name) ;
            Assert.AreEqual(expectedPartCost, phonePart.Cost) ;
            Assert.AreEqual(isBroken, phonePart.IsBroken) ;
        }

        [Test]
        public void TestNameValidation()
        {
            Assert.Throws<ArgumentException>(
                () => new LaptopPart(null, 10m));
        }

        [Test]
        public void TestCostValidationWithNegativePrice()
        {
            Assert.Throws<ArgumentException>(
                () => new LaptopPart("RamCard", -10m));
        }

        [Test]
        public void TestCostValidationWithNullPrice()
        {
            Assert.Throws<ArgumentException>(
                () => new LaptopPart("RamCard", 0m));
        }
        
        [Test]
        public void TestRepairMethod()
        {
            laptopPart.Repair();

            Assert.AreEqual(false,laptopPart.IsBroken);
        }

        [Test]
        public void TestReportMethod()
        {
            string expectedResult = $"{laptopPart.Name} - {laptopPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {laptopPart.IsBroken}";

            Assert.AreEqual(expectedResult, laptopPart.Report());
        }
    }
}