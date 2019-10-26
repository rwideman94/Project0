using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    abstract class Account
    {
        public int AccountID { get; }
        public decimal Balance { get; set; }
        public bool isActive { get; set; } = true;
        public bool isDeleted { get; set; }
        public List<Transaction> transactions = new List<Transaction>();
        public DateTime DateCreated { get; set; }

        public Account()
        {
            Balance = 0;
            AccountID = Bank.nextAccountID++;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine();
                transactions.Add(new Deposit
                {
                    AccountID = this.AccountID,
                    Amount = amount
                });
            }
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                Balance -= amount;
                Console.WriteLine();
                transactions.Add(new Withdrawl
                {
                    AccountID = this.AccountID,
                    Amount = amount
                });
            }
        }

        abstract public Bank.AccountType AccountType();
    }
}
