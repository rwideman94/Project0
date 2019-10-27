using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class WithdrawToLoan : Transaction
    {
        public int LoanID;
        public override TransactionType Type()
        {
            return TransactionType.WithdrawlToLoan;
        }
    }
}
