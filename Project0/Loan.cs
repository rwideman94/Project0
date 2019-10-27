﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Loan
    {
        public int LoanID = Bank.nextLoanID++;
        public decimal Principal { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; } = 0.25M;
        public bool PaidOff { get; set; } = false;
        public List<WithdrawlToLoan> payments = new List<WithdrawlToLoan>();

        public Loan()
        {
            Balance = Principal + (Principal * InterestRate);
        }

        public void PayAmount(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                payments.Add(new WithdrawlToLoan
                {Amount = amount, LoanID = this.LoanID, PaymentTime = DateTime.Now
                });
            }
            if (Balance == 0)
            {
                PaidOff = true;
            }
        }
    }
}