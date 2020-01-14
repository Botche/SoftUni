
using Chainblock.Models;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    class ChainBlockTests
    {
        private const int id = 1;
        private const TransactionStatus transactionStatus = TransactionStatus.Successfull;
        private const string from = "Ivan";
        private const string to = "Pesho";
        private const double amount = 100;

        private Transaction transaction;
        private ChainBlock chainblock;

        [SetUp]
        public void Setup()
        {
            transaction = new Transaction(id, transactionStatus, from, to, amount);
            chainblock = new ChainBlock();
        }
        
        [Test]
        public void TestConstructors()
        {
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, chainblock.Count);
        }
        
        [Test]
        public void TestAddMethod()
        {
            int expectedResult = 1;

            chainblock.Add(transaction);

            Assert.AreEqual(expectedResult, chainblock.Count);
        }
        
        [Test]
        public void TestAddMethodWithSameData()
        {
            int expectedResult = 1;

            chainblock.Add(transaction);
            chainblock.Add(transaction);

            Assert.AreEqual(expectedResult, chainblock.Count);
        }
        
        [Test]
        public void TestContainsTxMethod()
        {
            var expectedResult = true;

            chainblock.Add(transaction);

            Assert.AreEqual(expectedResult, chainblock.Contains(transaction));
        }
        
        [Test]
        public void TestContainsTxMethodWithExpectedResultFalse()
        {
            var expectedResult = false;

            chainblock.Add(transaction);

            Assert.AreEqual(expectedResult, chainblock.Contains(new Transaction(2,TransactionStatus.Aborted,"A","B",2)));
        }
        
        [Test]
        public void TestContainsIdMethod()
        {
            var expectedResult = true;

            chainblock.Add(transaction);

            Assert.AreEqual(expectedResult, chainblock.Contains(id));
        }

        [Test]
        public void TestContainsIdMethodWithExpectedResultFalse()
        {
            var expectedResult = false;

            chainblock.Add(transaction);

            Assert.AreEqual(expectedResult, chainblock.Contains(new Transaction(2, TransactionStatus.Aborted, "A", "B", 2)));
        }

        [Test]
        public void TestChangeTransactionStatus()
        {
            var expectedResult = TransactionStatus.Failed;

            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(id, TransactionStatus.Failed);

            Assert.AreEqual(expectedResult, transaction.Status);
        }

        [Test]
        public void TestChangeTransactionStatusWithBadData()
        {
            Assert.Throws<ArgumentException>(()
                => chainblock.ChangeTransactionStatus(id, TransactionStatus.Failed));
        }

        [Test]
        public void TestRemove()
        {
            var expectedResult = 0;

            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(id);

            Assert.AreEqual(expectedResult, chainblock.Count);
        }

        [Test]
        public void TestRemoveWithBadData()
        {
            Assert.Throws<InvalidOperationException>(()
                => chainblock.RemoveTransactionById(id));
        }

        [Test]
        public void TestGetById()
        {
            var expectedResult = transaction;

            chainblock.Add(transaction);

            Assert.AreEqual(expectedResult, chainblock.GetById(id));
        }

        [Test]
        public void TestGetByIdWithBadData()
        {
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetById(id));
        }
    }
}
