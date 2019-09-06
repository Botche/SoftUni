using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] data = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            database = new Database.Database(data);
        }

        [Test]
        public void TestIfConstructorWorks()
        {
            int expectedCount = 2;
            Assert.That(expectedCount==database.Count);
        }

        [Test]
        public void TestAdding()
        {
            int expectedCount = 3;

            database.Add(3);

            Assert.AreEqual(expectedCount, database.Count);
        }
        
        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(17));
        }

        [Test]
        public void TestRemoving()
        {
            int expectedCount = 1;
            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestRemovingWhenEmpty()
        {
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [Test]
        public void TestFetch()
        {
            int[] result = database.Fetch();
            CollectionAssert.AreEqual(data, result);
        }
    }
}