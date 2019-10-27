using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class TermDeposit
    {

        public int TDID = Bank.nextTDID++;
        public decimal Amount { get; set; }
        public decimal withdrawlAmount { get; set; }
        public decimal InterestRate { get; } = 0.15;
        public int TermYears { get; set; }
        public DateTime DateCreated { get; set; }

        public TermDeposit()
        {
            withdrawlAmount = Amount + (Amount * InterestRate);
        }

        public bool withdraw()
        {
            if (MaturityCheck())
            {
                Amount = 0;
                return true;
            }
            return false;
        }

        public bool MaturityCheck()
        {
            TimeSpan timeDifference = (DateTime.Now).Subtract(DateCreated);
            int daysSinceCreation = (int)timeDifference.TotalDays;
            int yearsSinceCreation = daysSinceCreation / 365;
            if (yearsSinceCreation >= TermYears)
            {
                return true;
            }
            return false;
        }
    }
}
