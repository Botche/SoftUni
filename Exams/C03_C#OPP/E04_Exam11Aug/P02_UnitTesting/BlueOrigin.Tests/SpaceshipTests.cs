namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;
        private const string name = "Apolo";
        private const int capacity = 1;

        [SetUp]
        public void SetUp()
        {
            spaceship = new Spaceship(name, capacity);
        }

        [Test]
        public void TestConstructor()
        {
            var expectedCount = 0;

            Assert.AreEqual(name, spaceship.Name);
            Assert.AreEqual(capacity, spaceship.Capacity);

            Assert.AreEqual(expectedCount, spaceship.Count);
        }

        [Test]
        public void TestValidationNameWithNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Spaceship(null, capacity));
        }

        [Test]
        public void TestValidationNameWithEmptyString()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Spaceship("", capacity));
        }

        [Test]
        public void TestValidationForCapacity()
        {
            Assert.Throws<ArgumentException>(
                () => new Spaceship(name, -1));
        }

        [Test]
        public void TestAddMethod()
        {
            var expectedCount = 1;

            var astronaut = new Astronaut("ivan", 30);

            spaceship.Add(astronaut);

            Assert.AreEqual(expectedCount, spaceship.Count);
        }

        [Test]
        public void TestAddMethodWithFullCapacity()
        {
            var astronaut = new Astronaut("ivan", 30);

            spaceship.Add(astronaut);

            astronaut = new Astronaut("gosho", 50);

            Assert.Throws<InvalidOperationException>(
                () => spaceship.Add(astronaut));
        }

        [Test]
        public void TestAddMethodWithExistingMember()
        {
            spaceship = new Spaceship(name, 2);

            var astronaut = new Astronaut("ivan", 30);

            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(
                () => spaceship.Add(astronaut));
        }

        [Test]
        public void TestRemove()
        {
            var expectedResult = true;

            var astronaut = new Astronaut("ivan", 30);

            spaceship.Add(astronaut);

            Assert.AreEqual(expectedResult, spaceship.Remove("ivan"));
        }

        [Test]
        public void TestRemoveOtherGuy()
        {
            var expectedResult = false;

            Assert.AreEqual(expectedResult, spaceship.Remove("pesho"));
        }
    }
}