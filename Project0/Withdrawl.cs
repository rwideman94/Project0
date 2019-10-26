using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Withdrawl : Transaction
    {
        public override TransactionType Type()
        {
            return TransactionType.Withdrawl;
        }
    }
}
