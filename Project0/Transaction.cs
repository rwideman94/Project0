using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{

    public enum TransactionType
    {
        Withdrawl,
        Deposit,
        TransferOut,
        TransferIn,
        WithdrawlToLoan,
        DepositFromTermDeposit
    }

    abstract class Transaction
    {
       public DateTime TransTime { get; set; }
       public int AccountID { get; set; }
       public decimal Amount { get; set; }

        public Transaction()
        {
            TransTime = DateTime.Now;
        }

       public abstract TransactionType Type();
    }
}
