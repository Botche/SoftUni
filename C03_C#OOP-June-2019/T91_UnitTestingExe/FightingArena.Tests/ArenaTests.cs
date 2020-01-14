using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void TestEnrollWorkCorrectly()
        {
            var warrior = new Warrior("Pesho", 10, 100);

            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestEnrollingExistingWarrior()
        {
            var warrior = new Warrior("Pesho", 10, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior));
        }

        [Test]
        public void TestCount()
        {
            var expectedCount = 1;

            var warrior = new Warrior("Pesho", 10, 50);

            arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, arena.Count);
        }
        
        [Test]
        public void TestFighting()
        {
            var expectedAttHp = 95;
            var expectedDefHp = 40;

            var attacker = new Warrior("Pesho", 10, 100);
            var defender = new Warrior("Gosho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttHp, attacker.HP);
            Assert.AreEqual(expectedDefHp, defender.HP);
        }

        [Test]
        public void TestFightingMissingWarrior()
        {
            var attacker = new Warrior("Pesho", 10, 100);
            var defender = new Warrior("Gosho", 10, 100);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(attacker.Name, defender.Name));
        }
    }
}
