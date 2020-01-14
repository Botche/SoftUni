using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(15, 10);
        }

        [Test]
        public void TestAttackDummyAndItLoseHp()
        {
            int expectedDummyHealthPoints = 5;

            axe.Attack(dummy);

            Assert.AreEqual(expectedDummyHealthPoints, dummy.Health);
        }

        [Test]
        public void TestAttackDummyWhenItsDead()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy));
        }

        [Test]
        public void TestGiveXpFromDeadDummy()
        {
            int expectedXp = 10;

            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.AreEqual(expectedXp, dummy.GiveExperience());
        }

        [Test]
        public void TestGiveXpFromAliveDummy()
        {
            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience());
        }
    }
}
