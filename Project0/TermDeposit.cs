using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class TermDeposit
    {

        public int TDID = Bank.nextTDID++;
        public decimal Amount { get; set; }
        public double InterestRate { get; } = 0.15;
        public int TermYears { get; set; }
        public bool reachedMaturity { get; set; } = false;
        public DateTime DateCreated { get; set; }

        // determine # of years since creation
        //   ((int)(((DateTime.Now).Subtract(DateCreated)).TotalDays) / 365) < TermYears

        public void withdraw()
        {
            //if ()
            //{
                Amount = 0;
            //}
        }

        public void Print()
        {
            Console.WriteLine($"Term Deposit ID #{TDID}");
            Console.WriteLine($"Currently holding ${Amount} at a {InterestRate}% intreset rate.");
            if (reachedMaturity)
            {
                Console.WriteLine("I'm ready to be withdrawn.");
            }else
            {
                Console.WriteLine("I still haven't reached maturity yet.");
            }
        }
    }
}
