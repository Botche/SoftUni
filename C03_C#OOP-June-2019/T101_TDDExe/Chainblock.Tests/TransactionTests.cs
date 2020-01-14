using System;

using NUnit.Framework;
using Chainblock.Models;

namespace Chainblock.Tests
{
    class TransactionTests
    {
        private const int id = 1;
        private const TransactionStatus transactionStatus = TransactionStatus.Successfull;
        private const string from = "Ivan";
        private const string to = "Pesho";
        private const double amount = 100;

        private Transaction transaction;

        [SetUp]
        public void Setup()
        {
            transaction = new Transaction(id, transactionStatus, from, to, amount);
        }

        [Test]
        public void TestConstructors()
        {
            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(transactionStatus, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        public void TestFromValidationWithNull()
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(id, transactionStatus, null, to, amount));
        }

        [Test]
        public void TestFromValidationWithEmptyString()
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(id, transactionStatus, "", to, amount));
        }

        [Test]
        public void TestToValidationWithNull()
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(id, transactionStatus, null, to, amount));
        }

        [Test]
        public void TestToValidationWithEmptyString()
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(id, transactionStatus, "", to, amount));
        }

        [Test]
        public void TestAmountValidationWithZero()
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(id, transactionStatus, from, to, 0));
        }

        [Test]
        public void TestAmountValidationWithNegative()
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(id, transactionStatus, from, to, -1));
        }
    }
}
