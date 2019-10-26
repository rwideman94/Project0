using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Bank
    {

        private DateTime date = DateTime.Now;

        public enum AccountType
        {
            Business,
            Checking
        }

        public static int nextCustomerID = 1001;
        public static int nextAccountID = 2001;
        public static int nextLoanID = 3001;
        public static int nextTDID = 4001;

        public List<Customer> customers = new List<Customer>();

        public int RegisterCustomer(string fName, string lName)
        {
            Customer newCust = new Customer
            {
                FirstName = fName,
                LastName = lName,
                CustomerID = nextCustomerID++
            };
            customers.Add(newCust);
            return newCust.CustomerID;
        }

        public int RegisterCustomer(string fName, string lName, string phoneNum)
        {
            Customer newCust = new Customer
            {
                FirstName = fName,
                LastName = lName,
                PhoneNumber = phoneNum,
                CustomerID = nextCustomerID++
            };
            customers.Add(newCust);
            return newCust.CustomerID;
        }

        public Customer FindCustomerByID(int ID)
        {
            return customers.Find(c => c.CustomerID == ID);
        }

        public Customer FindCustomerByName(string lName, string fName)
        {
            return customers.Find(c => (c.FirstName == fName && c.LastName == lName));
        }

        public bool customerExists(int ID)
        {
            Customer customer = FindCustomerByID(ID);
            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool confirmAccountOwnership(int customerID, int accountID)
        {
            Customer customer = FindCustomerByID(customerID);
            Account acct = customer.findAccountByID(accountID);
            if (acct != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool confirmLoanOwnership(int customerID, int loanID)
        {
            Customer customer = FindCustomerByID(customerID);
            Loan loan = customer.findLoanByID(loanID);
            if (loan != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool confirmTDOwnership(int customerID, int termDID)
        {
            Customer customer = FindCustomerByID(customerID);
            TermDeposit termD = customer.findTDByID(termDID);
            if (termD != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
