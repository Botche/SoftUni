namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            softPark = new SoftPark();
        }

        [Test]
        public void TestConstructor()
        {
            var expectedCount = 12;

            Assert.AreEqual(expectedCount, softPark.Parking.Count);
        }

        [Test]
        public void TestParkingCar()
        {
            var car = new Car("Honda", "Gabrovo");
            var expectedResult = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(expectedResult, softPark.ParkCar("A1", car));
        }

        [Test]
        public void TestParkingAtNotExistingParkingSpot()
        {
            var car= new Car("Honda", "Gabrovo");

            Assert.Throws<ArgumentException>(
                () => softPark.ParkCar("D5", car));
        }

        [Test]
        public void TestParkingAtNotEmptyParkingSpot()
        {
            var car= new Car("Honda", "Gabrovo");
            var secondCar = new Car("Honda", "Gabrovo");

            softPark.ParkCar("A1",car);

            Assert.Throws<ArgumentException>(
                () => softPark.ParkCar("A1", secondCar));
        }

        [Test]
        public void TestParkingAnExistingCar()
        {
            var car= new Car("Honda", "Gabrovo");
            var secondCar = new Car("Honda", "Gabrovo");

            softPark.ParkCar("A1",car);

            Assert.Throws<InvalidOperationException>(
                () => softPark.ParkCar("A3", secondCar));
        }

        [Test]
        public void TestRemovingCar()
        {
            var car = new Car("Honda", "Gabrovo");
            var expectedResult = $"Remove car:{car.RegistrationNumber} successfully!";

            softPark.ParkCar("A1", car);

            Assert.AreEqual(expectedResult, softPark.RemoveCar("A1", car));
        }

        [Test]
        public void TestRemovingCarAtNotExistingSpot()
        {
            var car = new Car("Honda", "Gabrovo");

            softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(
                () => softPark.RemoveCar("A5", car));
        }

        [Test]
        public void TestRemovingCarAtEmptySpot()
        {
            var car = new Car("Honda", "Gabrovo");

            softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(
                () => softPark.RemoveCar("A3", car));
        }
    }
}