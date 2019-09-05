using NUnit.Framework;
using System;

namespace Tests
{
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void TestAxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9),
                "Axe Durability doesnt change after attack");
        }

        [Test]
        public void TestAttackingWithBrokenAxe()
        {
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy));
        }
    }
}