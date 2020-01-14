using NUnit.Framework;
using Service.Models.Devices;
using Service.Models.Parts;
using System;
using System.Linq;

namespace Service.Tests
{
    public class DeviceTests
    {
        private const string laptopName = "Lenovo";

        private const string pcName = "Razer";

        private const string phoneName = "Huawei";

        private Device laptop;
        private Device pc;
        private Device phone;

        [SetUp]
        public void Setup()
        {
            laptop = new Laptop(laptopName);
            pc = new PC(pcName);
            phone = new Phone(phoneName);
        }

        [Test]
        public void TestLaptopConstructor()
        {
            Assert.IsNotNull(laptop.Parts);
            Assert.AreEqual(laptopName, laptop.Make);
        }

        [Test]
        public void TestPcConstructor()
        {
            Assert.IsNotNull(pc.Parts);
            Assert.AreEqual(pcName,pc.Make);
        }

        [Test]
        public void TestPhoneConstructor()
        {
            Assert.IsNotNull(phone.Parts);
            Assert.AreEqual(phoneName,phone.Make);
        }

        [Test]
        public void TestMakeValidation()
        {
            Assert.Throws<ArgumentException>(
                () => new Laptop(null));
        }

        [Test]
        public void TestAddingPartInLaptop()
        {
            var expectedCount = 1;
            
            var part = new LaptopPart("laptopMonitor", 10m);

            laptop.AddPart(part);

            Assert.AreEqual(expectedCount, laptop.Parts.Count);
        }

        [Test]
        public void TestAddingAnExistingPartInLaptop()
        {
            var part = new LaptopPart("laptopMonitor", 10m);

            laptop.AddPart(part);

            Assert.Throws<InvalidOperationException>(
                () => laptop.AddPart(part));
        }

        [Test]
        public void TestAddingAPhonePartInLaptop()
        {
            var part = new PhonePart("phoneDisplay", 10m);

            Assert.Throws<InvalidOperationException>(
                () => laptop.AddPart(part));
        }

        [Test]
        public void TestAddingALaptopPartInPhone()
        {
            var part = new LaptopPart("something", 10m);

            Assert.Throws<InvalidOperationException>(
                () => phone.AddPart(part));
        }

        [Test]
        public void TestAddingALaptopPartInPc()
        {
            var part = new LaptopPart("phoneDisplay", 10m);

            Assert.Throws<InvalidOperationException>(
                () => pc.AddPart(part));
        }

        [Test]
        public void TestRemovingPart()
        {
            var expectedCount = 0;

            var part = new LaptopPart("phoneDisplay", 10m);

            laptop.AddPart(part);
            laptop.RemovePart(part.Name);

            Assert.AreEqual(expectedCount, laptop.Parts.Count);
        }

        [Test]
        public void TestRemovingPartWithNullName()
        {
            Assert.Throws<ArgumentException>(
                () => laptop.RemovePart(null));
        }

        [Test]
        public void TestRemovingPartWithEmptyName()
        {
            Assert.Throws<ArgumentException>(
                () => laptop.RemovePart(string.Empty));
        }

        [Test]
        public void TestRemovingNotExistingPart()
        {
            Assert.Throws<InvalidOperationException>(
                () => laptop.RemovePart("rom"));
        }

        [Test]
        public void TestRepairingPartWithNullName()
        {
            Assert.Throws<ArgumentException>(
                () => laptop.RepairPart(null)) ;
        }

        [Test]
        public void TestRepairingPartWithEmptyName()
        {
            Assert.Throws<ArgumentException>(
                () => laptop.RepairPart(string.Empty)) ;
        }

        [Test]
        public void TestRepairingNotExistingPart()
        {
            Assert.Throws<InvalidOperationException>(
                () => laptop.RepairPart("rom"));
        }

        [Test]
        public void TestRepairingRepairedPart()
        {
            var part = new LaptopPart("something", 1m,true);

            laptop.AddPart(part);
            laptop.RepairPart(part.Name);

            Assert.Throws<InvalidOperationException>(
                () => laptop.RepairPart(part.Name));
        }

        [Test]
        public void TestRepairingPart()
        {
            var part = new LaptopPart("something", 1m,true);

            laptop.AddPart(part);
            laptop.RepairPart(part.Name);

            var partToCheck = laptop.Parts.First();

            Assert.AreEqual(false,partToCheck.IsBroken);
        }
    }
}
