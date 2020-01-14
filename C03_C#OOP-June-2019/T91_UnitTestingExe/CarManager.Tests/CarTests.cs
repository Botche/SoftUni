using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Honda", "Civik", 5.6, 100);
        }

        [Test]
        public void TestConstructors()
        {
            Assert.That(car.FuelAmount == 0);
            Assert.AreEqual("Honda", car.Make);
            Assert.AreEqual("Civik", car.Model);
            Assert.AreEqual(100, car.FuelCapacity);
            Assert.AreEqual(5.6, car.FuelConsumption);
        }

        [Test]
        public void TestValidationMake()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("", "Civik", 5.5, 10));
        }

        [Test]
        public void TestValidationModel()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "", 5.5, 10));
        }

        [Test]
        public void TestValidationFuelConsumption()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Civik", 0, 10));
        }

        [Test]
        public void TestValidationFuelConsumptionWithNegative()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Civik", -3, 10));
        }

        [Test]
        public void TestValidationFuelCapacity()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Civik", 5.5, -2));
        }

        [Test]
        public void TestValidationFuelCapacityWithZero()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Civik", 5.5, 0));
        }

        [Test]
        public void TestRefuelWithNegativeFuel()
        {
            var negativeFuel = -2;

            Assert.Throws<ArgumentException>(
                () => car.Refuel(negativeFuel));
        }

        [Test]
        public void TestRefuelWithZeroFuel()
        {
            var zeroFuel = 0;

            Assert.Throws<ArgumentException>(
                () => car.Refuel(zeroFuel));
        }

        [Test]
        public void TestRefuelWithProperlyValue()
        {
            var fuelToRefuel = 10;
            var expectedResult = fuelToRefuel + car.FuelAmount;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        public void TestRefuelWithFuelMoreThanCapacity()
        {
            var fuelToRefuel = 150;
            var expectedResult = car.FuelCapacity;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        public void TestDrive()
        {
            car.Refuel(50);
            double distance = 10;
            double expectedResult = car.FuelAmount - (distance / 100) * car.FuelConsumption;

            car.Drive(distance);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        public void TestDriveWhileEmptyTank()
        {
            var distance = 100;

            Assert.Throws<InvalidOperationException>(
                ()=>car.Drive(distance));
        }
    }
}