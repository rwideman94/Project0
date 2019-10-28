using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerID { get; set; }
        public string PhoneNumber { get; set; }
        public List<BusinessAccount> BAccounts { get; set; } = new List<BusinessAccount>();
        public List<CheckingAccount> CAccounts { get; set; } = new List<CheckingAccount>();
        public List<Loan> Loans { get; set; } = new List<Loan>();
        public List<TermDeposit> TermDeposits { get; set; } = new List<TermDeposit>();
        public int TotalNumAccts { get; set; }
        public int TotalActiveAccts { get; set; }

        public void AddAccount(Bank.AccountType type)
        {
            switch (type)
            {
                case Bank.AccountType.Business:
                    {
                        BAccounts.Add(new BusinessAccount());
                        TotalNumAccts++;
                        TotalActiveAccts++;
                        break;
                    }
                case Bank.AccountType.Checking:
                    {
                        CAccounts.Add(new CheckingAccount());
                        TotalNumAccts++;
                        TotalActiveAccts++;
                        break;
                    }
            }
        }

        public void removeAccount(Account toRemove)
        {
            toRemove.isClosed = true;
            toRemove.isActive = false;
            TotalActiveAccts--;
        }

        public void AddLoan(decimal amount)
        {
            Loans.Add(new Loan { Principal = amount, Balance = amount + (amount * Loan.InterestRate) });
        }

        //not used to simulate time passing in the UI
        public void AddTD(decimal amount, int years)
        {
            TermDeposits.Add(new TermDeposit { Amount = amount, TermYears = years, DateCreated = DateTime.Now });
        }

        public void TransferFunds(Account TranFrom, Account TranTo, decimal amount)
        {
            TranFrom.Balance -= amount;
            TranTo.Balance += amount;
            TranFrom.transactions.Add(new TransferOut
            {
                AccountID = TranFrom.AccountID,
                AccountIDTo = TranTo.AccountID,
                Amount = amount
            }); ;
            TranTo.transactions.Add(new TransferIn
            {
                AccountID = TranTo.AccountID,
                AccountIDFrom = TranFrom.AccountID,
                Amount = amount
            });
        }

        public Account findAccountByID(int ID)
        {
            Account returnAccount;
            returnAccount = BAccounts.Find(acct => acct.AccountID == ID);
            if (returnAccount == null)
            {
                returnAccount = CAccounts.Find(acct => acct.AccountID == ID);
            }
            return returnAccount;
        }

        public Loan findLoanByID(int ID)
        {
            return Loans.Find(loan => loan.LoanID == ID);
        }

        public TermDeposit findTDByID(int ID)
        {
            return TermDeposits.Find(TD => TD.TDID == ID);
        }
    }
}
