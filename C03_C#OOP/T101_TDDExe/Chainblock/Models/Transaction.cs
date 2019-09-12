using System;

using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private string from;
        private string to;
        private double amount;

        public Transaction(int id,TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id { get; set; }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get => from;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("From form cannot be null or empty");
                }

                from = value;
            }
        }

        public string To
        {
            get => to;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("To form cannot be null or empty");
                }

                to = value;
            }
        }

        public double Amount
        {
            get => amount;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Amount cannot be null or negative");
                }

                amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            return this.From.CompareTo(other.From);
        }
    }
}
