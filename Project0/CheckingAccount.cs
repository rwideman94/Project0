using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class CheckingAccount : Account
    {
        public double InterestRate = 0.1;
        public override void Withdraw(decimal Amount)
        {
            if (Amount <= Balance)
            {
                base.Withdraw(Amount);
            }
        }

        public override Bank.AccountType AccountType()
        {
            return Bank.AccountType.Checking;
        }
    }
}
