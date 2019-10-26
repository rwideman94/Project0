using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class TransferIn : Transaction
    {
        public int AccountIDFrom { get; set; }

        public override TransactionType Type()
        {
            return TransactionType.TransferIn;
        }
    }
}
