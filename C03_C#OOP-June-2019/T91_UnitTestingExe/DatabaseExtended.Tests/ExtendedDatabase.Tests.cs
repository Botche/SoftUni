using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private readonly Person[] data = new Person[] {
                new Person(123,"Ivan"),
                new Person(2345,"Gosho")};

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase(data);
        }

        [Test]
        public void TestIfConstructorWorks()
        {
            int expectedCount = 2;

            Assert.That(expectedCount == database.Count);
        }

        [Test]
        public void TestAdding()
        {
            int expectedCount = 3;

            database.Add(new Person(132,"Ivankata"));

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddingPersonWithExistingId()
        {
            var personWhoBreaks = new Person(123, "BadName");

            Assert.Throws<InvalidOperationException>(
                () => database.Add(personWhoBreaks));
        }
        
        [Test]
        public void TestAddingPersonWithExistingName()
        {
            var personWhoBreaks = new Person(1234, "Ivan");

            Assert.Throws<InvalidOperationException>(
                () => database.Add(personWhoBreaks));
        }

        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(new Person(i,$"Ivan {i}"));
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(17,$"Dragan")));
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
        public void TestFindByNameIfThereIsPersonWithThatName()
        {
            var personToBeFound = new Person(123, "Ivan");

            Assert.AreEqual(personToBeFound.UserName, database.FindByUsername(personToBeFound.UserName).UserName); ;
        }

        [Test]
        public void TestFindByNameWithEmptyName()
        {
            var personToBeFound = new Person(123, "");

            Assert.Throws<ArgumentNullException>(
               () => database.FindByUsername(personToBeFound.UserName));
        }

        [Test]
        public void TestFindByNameIfThereIsPersonWithFakeName()
        {
            var personToBeFound = new Person(4, "Dragancho");

            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername(personToBeFound.UserName));
        }

        [Test]
        public void TestFindByNameIfThereIsPersonWithThatId()
        {
            var personToBeFound = new Person(123, "Ivan");

            Assert.AreEqual(personToBeFound.Id, database.FindById(personToBeFound.Id).Id); ;
        }

        [Test]
        public void TestFindByNameWithNegativeId()
        {
            var personToBeFound = new Person(-42, "Ivan");

            Assert.Throws<ArgumentOutOfRangeException>(
               () => database.FindById(personToBeFound.Id));
        }

        [Test]
        public void TestFindByNameIfThereIsPersonWithFakeId()
        {
            var personToBeFound = new Person(4, "Dragancho");

            Assert.Throws<InvalidOperationException>(
                () => database.FindById(personToBeFound.Id));
        }
    }
}