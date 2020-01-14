using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Models
{
    public class ChainBlock : IChainblock
    {
        private List<ITransaction> transactions;

        public ChainBlock()
        {
            transactions = new List<ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if(!this.Contains(tx))
            {
                transactions.Add(tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var tx = transactions.FirstOrDefault(t => t.Id == id);

            if (tx==null)
            {
                throw new ArgumentException("Such a transaction doesnt exits.");
            }

            tx.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            var tx = transactions.FirstOrDefault(t => t.Id == id);

            if (tx!=null)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            var result = transactions
                .Where(t => t.Amount >= lo && t.Amount <= hi);

            if (result == null)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var result = transactions.OrderByDescending(t=>t.Amount)
                .ThenBy(t=>t.Id);

            if (result == null)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var result = transactions.Where(t => t.Status == status);
            var receivers = new List<String>();

            if (result == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var item in result)
            {
                receivers.Add(item.To);
            }
            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var sendersTx = transactions.Where(t => t.Status == status);
            var senders = new List<String>();

            if (sendersTx == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var item in sendersTx)
            {
                senders.Add(item.From);
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            var tx = transactions.FirstOrDefault(t => t.Id == id);

            if (tx == null)
            {
                throw new InvalidOperationException("Such a transaction doesnt exists.");
            }

            return tx;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = transactions.Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount <= hi);

            if (result==null)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var tx = transactions.Where(t => t.To == receiver)
                .OrderBy(t => t.Amount)
                .ThenBy(t=>t.Id);

            if (tx == null)
            {
                throw new InvalidOperationException();
            }

            return tx;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var tx = transactions.Where(t => t.From == sender)
                .Where(t=>t.Amount>=amount)
                .OrderByDescending(t=>t.Amount);

            if (tx == null)
            {
                throw new InvalidOperationException();
            }

            return tx;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var tx = transactions.Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);

            if (tx == null)
            {
                throw new InvalidOperationException();
            }

            return tx;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var transactionsByStatus = transactions.Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);

            if (transactionsByStatus==null)
            {
                throw new InvalidOperationException();
            }

            return transactionsByStatus;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var tx = transactions.Where(t => t.Status == status)
                .Where(t=>t.Amount<=amount);

            if (tx == null)
            {
                throw new InvalidOperationException();
            }

            return tx;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void RemoveTransactionById(int id)
        {
            var tx = transactions.FirstOrDefault(t => t.Id == id);

            if (tx == null)
            {
                throw new InvalidOperationException("Such a transaction doesnt exists.");
            }

            transactions.Remove(tx);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
