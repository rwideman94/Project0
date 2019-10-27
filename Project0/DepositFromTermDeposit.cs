using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class DepositFromTermDeposit : Transaction
    {
        public int TDID;
        public override TransactionType Type()
        {
            return TransactionType.DepositFromTermDeposit;
        }
    }
}
