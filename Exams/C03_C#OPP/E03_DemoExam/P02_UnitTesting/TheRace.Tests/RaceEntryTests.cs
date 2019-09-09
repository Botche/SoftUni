using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void TestNullAddRider()
        {
            UnitRider unitRider = null;
            Assert.That(() => raceEntry.AddRider(unitRider),
                Throws.InvalidOperationException.With.Message.EqualTo("Rider cannot be null."));
        }
        [Test]
        public void TestRaceConstainsRider()
        {
            UnitRider unitRider = new UnitRider("ivan", new UnitMotorcycle("", 3, 3));
            UnitRider unitRider1 = new UnitRider("ivan", new UnitMotorcycle("", 3, 3));
            raceEntry.AddRider(unitRider);

            Assert.That(() => raceEntry.AddRider(unitRider),
                Throws.InvalidOperationException.With.Message.EqualTo(string.Format("Rider {0} is already added.","ivan")));
        }
        [Test]
        public void TestRaceAddingRider()
        {

            UnitRider unitRider = new UnitRider("ivan", new UnitMotorcycle("", 3, 3));
            Assert.That(raceEntry.AddRider(unitRider) == string.Format("Rider {0} added in race.", "ivan"));

        }
        [Test]
        public void TestExceptionHorsePower()
        {
            UnitRider unitRider = new UnitRider("ivan", new UnitMotorcycle("", 3, 3));
            raceEntry.AddRider(unitRider);

            Assert.That(() => raceEntry.CalculateAverageHorsePower(),
                Throws.InvalidOperationException.With.Message.EqualTo("The race cannot start with less than 2 participants."));
        }
        [Test]
        public void TestHorsePower()
        {
            UnitRider unitRider = new UnitRider("ivan", new UnitMotorcycle("", 3, 3));
            raceEntry.AddRider(unitRider);
            UnitRider unitRider1 = new UnitRider("ivankata", new UnitMotorcycle("", 3, 3));
            raceEntry.AddRider(unitRider1);

            Assert.That(raceEntry.CalculateAverageHorsePower() == 3);
        }
    }
}