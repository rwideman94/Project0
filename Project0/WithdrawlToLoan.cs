using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class WithdrawlToLoan : Transaction
    {
        public DateTime PaymentTime { get; set; }
        public int LoanID { get; set; }
        public override TransactionType Type()
        {
            return TransactionType.WithdrawlToLoan;
        }
    }
}
