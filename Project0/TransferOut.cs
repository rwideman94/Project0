using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class TransferOut : Transaction
    {
        public int AccountIDTo { get; set; }

        public override TransactionType Type() {
            return TransactionType.TransferOut;
        }
    }
}
