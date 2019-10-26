using System;

namespace Project0
{
    class BusinessAccount : Account
    {
        public decimal overdraftFees;
        public override void Withdraw(decimal amount)
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
            if (Balance < 0)
            {
                decimal fees = Balance * 0.1M;
                overdraftFees += fees;
                Balance += fees;
            }

        }
        public override Bank.AccountType AccountType()
        {
            return Bank.AccountType.Business;
        }
    }
}
