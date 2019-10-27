﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class TempUI
    {
        private static int currentCustomerID = 0;
        private static Customer currentCustomer;
        private Bank bank = new Bank();
        private delegate void Menu();
        static Menu menu;


        private readonly string HelpMessage = "Type \"Main\" at any input to return to the main menu.\n" +
            "Or,Type \"Exit\" at any input to close the application.";
        public void Run()
        {
            Console.WriteLine("Welcome to The Central Bank of Awfully Sinful Sailors (CBASS)");
            menu = new Menu(StartUp);
            for (; ; )
            {
                menu();
                Console.Clear();
            }
        }
        private void StartUp()
        {
            Console.WriteLine("" +
                "***Main Menu***\n" +
                "Please enter your selection.\n" +
                "A: Returning Customer\n" +
                "B: Register New customer" +
                "Type \"Exit\" to close the application.\n");
            string input = Utility.ReadString();
            switch (input)
            {
                case "a":
                case "A":
                    {
                        int AttemptsRemaining = 4;
                        do
                        {
                            Console.WriteLine("What is your Customer ID?");
                            int ID = Utility.ReadInt();
                            if (ID == Utility.ExitCode)
                            {
                                menu = Exit;
                                return;
                            }

                            if (ID == -1)
                            {
                                Console.WriteLine("That is not a valid ID. Please try again.");
                                Console.WriteLine($"{--AttemptsRemaining} Attempts Remaining");
                            }
                            else if (!bank.customerExists(ID))
                            {
                                Console.WriteLine("There is not customer by that ID. Please try again.");
                                Console.WriteLine($"{--AttemptsRemaining} Attempts Remaining");
                            }
                            else
                            {
                                currentCustomerID = ID;
                                currentCustomer = bank.FindCustomerByID(ID);
                                menu = MainMenu;
                                return;
                            }


                        } while (AttemptsRemaining > 0);
                        Console.WriteLine("Too many failed log in Attempts. Returning to main Menu.\n Press Enter to Continue.");
                        Console.ReadLine();
                        menu = StartUp;
                        return;
                    }
                case "b":
                case "B":
                    {
                        string fName = "";
                        string lName = "";
                        string phoneNum = "";
                        do
                        {
                            do
                            {
                                Console.WriteLine("Enter your first name");
                                fName = Utility.ReadString();
                                if (fName == Utility.ExitCode.ToString())
                                {
                                    menu = Exit;
                                    return;
                                }
                            } while (fName == "");
                            do
                            {
                                Console.WriteLine("Enter your last name");
                                lName = Utility.ReadString();
                                if (lName == Utility.ExitCode.ToString())
                                {
                                    menu = Exit;
                                    return;
                                }
                            } while (lName == "");

                            Console.WriteLine("What is your phone number?\n" +
                                "If you don't want to add one, just hit Enter");
                            phoneNum = Utility.ReadString();
                            if (phoneNum == Utility.ExitCode.ToString())
                            {
                                menu = Exit;
                                return;
                            }
                            if (phoneNum != "")
                            {
                                int newID = bank.RegisterCustomer(fName, lName, phoneNum);
                                Console.WriteLine($"Succesfully Registered. Your Customer ID is {newID}.\nLogging in to new account.");
                                currentCustomerID = newID;
                                currentCustomer = bank.FindCustomerByID(newID);
                                menu = MainMenu;
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                return;
                            }
                            else
                            {
                                int newID = bank.RegisterCustomer(fName, lName);
                                Console.WriteLine($"Succesfully Registered. Your Customer ID is {newID}.\nLogging in to new account.");
                                currentCustomerID = newID;
                                currentCustomer = bank.FindCustomerByID(newID);
                                menu = MainMenu;
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                return;
                            }
                        } while (true);
                    }
                case "exit":
                case "Exit":
                    {
                        menu = Exit;
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Please Enter one of the options available.\nPress Enter to continue.");
                        Console.ReadLine();
                        menu = StartUp;
                        return;
                    }
            }
        }
        private void MainMenu()
        {

            #region Menu Printing
            Console.WriteLine($"Hello, {currentCustomer.FirstName} {currentCustomer.LastName}.\n");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("" +
                "***Main Menu***\n" +
                "Please enter your selection.\n" +
                "A: Customer Summary\n" +
                "B: Open an Account\n" +
                "C: Close an Account\n" +
                "D: Deposit into an Account\n" +
                "E: Withdraw from an Account\n" +
                "F: Transfer between accounts\n" +
                "G: Take out a Loan\n" +
                "H: Make Term Deposit\n" +
                "I: Pay Loan Installment\n" +
                "J: Withdraw from Term Deposit\n" +
                "K: Account Transaction history\n" +
                "L: Log Out\n" +
                HelpMessage);
            #endregion

            string input = Utility.ReadString();
            if (UICheckForCommands(input))
            {
                return;
            }


            switch (input)
            {
                case "a":
                case "A":
                    {
                        menu = CustomerSummary;
                        return;
                    }
                case "b":
                case "B":
                    {
                        menu = OpenAccount;
                        return;
                    }
                case "c":
                case "C":
                    {
                        menu = CloseAccount;
                        return;
                    }
                case "d":
                case "D":
                    {
                        menu = Deposit;
                        return;
                    }
                case "e":
                case "E":
                    {
                        menu = Withdraw;
                        return;
                    }
                case "f":
                case "F":
                    {
                        menu = Transfer;
                        return;
                    }
                case "g":
                case "G":
                    {
                        menu = TakeLoan;
                        return;
                    }
                case "h":
                case "H":
                    {
                        menu = MakeTermDeposit;
                        return;
                    }
                case "i":
                case "I":
                    {
                        menu = PayLoan;
                        return;
                    }
                case "j":
                case "J":
                    {
                        menu = TermDepositWithdraw;
                        return;
                    }
                case "k":
                case "K":
                    {
                        menu = TransactionHistory;
                        return;
                    }
                case "l":
                case "L":
                    {
                        menu = LogOut;
                        return;
                    }
                case "":
                    {
                        Console.WriteLine("Please make a selection.\nPress Enter to Continue");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Please choose one of the available options.\nPress Enter to Continue");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
            }
        }
        private void CustomerSummary()
        {
            if (currentCustomer.TotalNumAccts > 0)
            {
                Console.WriteLine($"Accounts associated with Customer ID#{currentCustomer.CustomerID}");
                Console.WriteLine();
                Summary(currentCustomer);
                Console.WriteLine("\nPress Enter to Continue");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
            else
            {
                Console.WriteLine($"No accounts associated with Customer ID#{currentCustomer.CustomerID}\nPress Enter to Continue");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void OpenAccount()
        {
            Console.WriteLine(HelpMessage + "\n\n");
            Console.WriteLine(
                "What kind of account would you like to open?\n" +
                "A: Checking Account\n" +
                "B: Business Account\n");
            string newType = Utility.ReadString();
            if (UICheckForCommands(newType))
            {
                return;
            }
            switch (newType)
            {
                case "a":
                case "A":
                    {
                        currentCustomer.AddAccount(Bank.AccountType.Checking);
                        int newAcctID = currentCustomer.CAccounts[currentCustomer.CAccounts.Count - 1].AccountID;
                        Console.WriteLine($"Succefully created a new account. Account ID#{newAcctID}\nPress Enter to Continue");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                case "b":
                case "B":
                    {
                        currentCustomer.AddAccount(Bank.AccountType.Business);
                        int newAcctID = currentCustomer.BAccounts[currentCustomer.BAccounts.Count - 1].AccountID;
                        Console.WriteLine($"Succefully created a new account. Account ID#{newAcctID}\nPress Enter to Continue");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Account type. Did not create Account.\nPress Enter to return to main menu");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
            }
        }
        private void CloseAccount()
        {
            if (currentCustomer.TotalNumAccts > 0)
            {
                Console.WriteLine(HelpMessage + "\n\n");
                Console.WriteLine("Your accounts");
                PrintAccounts();
                Console.WriteLine("Enter the ID number of the account you would you like to close.");
                int closeID = Utility.ReadInt();
                if (UICheckForCommands(closeID))
                {
                    return;
                }
                Account toRemove = currentCustomer.findAccountByID(closeID);
                if (bank.confirmAccountOwnership(currentCustomer.CustomerID, closeID))
                {
                    if (toRemove.Balance > 0)
                    {
                        Console.WriteLine("There is money in this account. Please withdraw or transfer all funds before closing.\n" +
                            "Press Enter to return to the main Menu");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                    else if (toRemove.Balance < 0)
                    {
                        Console.WriteLine("This account has a negative balance. Please pay off the deficit before closing.\n" +
                            "Press Enter to return to the main Menu");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Are you sure you'd like to close account #{closeID}? Y/N");
                        string conf = Utility.ReadString();
                        if (UICheckForCommands(conf))
                        {
                            return;
                        }
                        switch (conf)
                        {
                            case "y":
                            case "Y":
                                {
                                    Console.WriteLine($"Closing account #{closeID}...");
                                    currentCustomer.removeAccount(toRemove);
                                    Console.WriteLine($"Closed account #{closeID}.\nPress Enter to return to the main Menu");
                                    Console.ReadLine();
                                    menu = MainMenu;
                                    return;
                                }
                            case "n":
                            case "N":
                                {
                                    Console.WriteLine($"Account closing Cancelled.\nPress Enter to return to the main Menu");
                                    Console.ReadLine();
                                    menu = MainMenu;
                                    return;
                                }
                            default:
                                {
                                    Console.WriteLine($"Invalid Input.\nAccount closing Cancelled.\nPress Enter to try again");
                                    Console.ReadLine();
                                    menu = CloseAccount;
                                    return;
                                }
                        }
                    }
                }
                else
                {

                    Console.WriteLine("That is not one of your accounts.\nPress Enter to try again.");
                    Console.ReadLine();
                    menu = CloseAccount;
                    return;
                }
            }
            else
            {
                Console.WriteLine("You need at least one account to be able to close an account\nPress Enter to Return to the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void Deposit()
        {
            if (currentCustomer.TotalNumAccts > 0)
            {
                Console.WriteLine(HelpMessage + "\n\n");
                Console.WriteLine("Your Accounts");
                PrintAccounts();
                Console.WriteLine("Which account would you like to deposit into?");
                int depID = Utility.ReadInt();
                if (UICheckForCommands(depID))
                {
                    return;
                }
                if (bank.confirmAccountOwnership(currentCustomer.CustomerID, depID))
                {
                    Account dep = currentCustomer.findAccountByID(depID);
                    Console.WriteLine($"How much would you like to deposit into account {depID}?");
                    decimal amount = Utility.ReadDec();
                    if (UICheckForCommands(amount))
                    {
                        return;
                    }
                    if (amount > 0)
                    {
                        Console.WriteLine($"Depositing ${amount} into account #{depID}... ");
                        dep.Deposit(amount);
                        Console.WriteLine($"Depositied ${amount}.");
                        PrintAccount(dep);
                        Console.WriteLine($"\n.Press Enter to return to the main menu.");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid amount.\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = Deposit;
                        return;
                    }
                }
                else
                {
                    if (depID > 0)
                    {
                        Console.WriteLine("That is not one of your accounts.\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = Deposit;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That isn't a valid account ID\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = Deposit;
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need at least one account to be able to make a deposit.\nPress Enter to return the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void Withdraw()
        {
            if (currentCustomer.TotalNumAccts > 0)
            {
                Console.WriteLine(HelpMessage + "\n\n");
                Console.WriteLine("Your Accounts");
                PrintAccounts();
                Console.WriteLine("Which account would you like to withdraw from?");
                int withdrawID = Utility.ReadInt();
                if (UICheckForCommands(withdrawID))
                {
                    return;
                }
                if (bank.confirmAccountOwnership(currentCustomer.CustomerID, withdrawID))
                {
                    Account withdrawAcct = currentCustomer.findAccountByID(withdrawID);
                    Console.WriteLine($"How much would you like to withdraw from account {withdrawID}?");
                    decimal amount = Utility.ReadDec();
                    if (UICheckForCommands(amount))
                    {
                        return;
                    }
                    if (amount > 0)
                    {
                        Console.WriteLine($"Withdrawing ${amount} into account #{withdrawID}... ");
                        withdrawAcct.Withdraw(amount);
                        Console.WriteLine($"Withdrawing ${amount}.");
                        PrintAccount(withdrawAcct);
                        Console.WriteLine($"\n.Press Enter to continue.");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a value greater than 0.\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = Withdraw;
                        return;
                    }
                }
                else
                {
                    if (withdrawID > 0)
                    {
                        Console.WriteLine("That is not one of your accounts.\nPress Enter to return to try again.");
                        Console.ReadLine();
                        menu = Withdraw;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That isn't a valid account ID\nPress Enter to return to try again.");
                        Console.ReadLine();
                        menu = Withdraw;
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need at least one account to be able to make a withdrawl\nPress Enter to return to the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void Transfer()
        {
            if (currentCustomer.TotalNumAccts > 1)
            {
                Console.WriteLine(HelpMessage + "\n\n");
                Console.WriteLine("Your Accounts");
                PrintAccounts();
                Console.WriteLine("Which account would you like to transfer from?");
                int fromID = Utility.ReadInt();
                if (UICheckForCommands(fromID))
                {
                    return;
                }
                if (bank.confirmAccountOwnership(currentCustomer.CustomerID, fromID))
                {
                    Account fromAcct = currentCustomer.findAccountByID(fromID);
                    Console.WriteLine("Which account would you like to transfer to?");
                    int toID = Utility.ReadInt();
                    if (UICheckForCommands(toID))
                    {
                        return;
                    }
                    if (UICheckForCommands(toID))
                    {
                        return;
                    }
                    if (bank.confirmAccountOwnership(currentCustomer.CustomerID, toID))
                    {
                        if (fromID == toID)
                        {
                            Console.WriteLine($"You can't transfer from an account to itself.\n.Press Enter to return to the main menu.");
                            Console.ReadLine();
                            menu = MainMenu;
                            return;
                        }
                        else
                        {
                            Account toAcct = currentCustomer.findAccountByID(toID);
                            Console.WriteLine($"How much would you like to transfer?");
                            decimal amount = Utility.ReadDec();
                            if (UICheckForCommands(amount))
                            {
                                return;
                            }
                            if (amount > 0)
                            {
                                if (amount <= fromAcct.Balance)
                                {
                                    Console.WriteLine($"Transfering ${amount} from account {fromID} to account #{toID}... ");
                                    currentCustomer.TransferFunds(fromAcct, toAcct, amount);
                                    Console.WriteLine($"Transfered ${amount}.");
                                    PrintAccount(fromAcct);
                                    Console.WriteLine();
                                    PrintAccount(toAcct);
                                    Console.WriteLine($"\n.Press Enter to return to the main menu.");
                                    Console.ReadLine();
                                    menu = MainMenu;
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine($"There aren't that many funds in Account #{fromID}.\n.Press Enter to try again.");
                                    Console.ReadLine();
                                    menu = Transfer;
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid amount.\nPress Enter to try again.");
                                Console.ReadLine();
                                menu = Transfer;
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (toID > 0)
                        {
                            Console.WriteLine("That is not one of your accounts.\nPress Enter to return to try again.");
                            Console.ReadLine();
                            menu = Transfer;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("That isn't a valid account ID\nPress Enter to return to try again.");
                            Console.ReadLine();
                            menu = Transfer;
                            return;
                        }
                    }

                }
                else
                {
                    if (fromID > 0)
                    {
                        Console.WriteLine("That is not one of your accounts.\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = Transfer;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That isn't a valid account ID\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = Transfer;
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need at least two accounts to be able to transfer\nPress Enter to return to the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void TakeLoan()
        {
            Console.WriteLine(HelpMessage + "\n\n");
            Console.WriteLine($"How much do you need?\n(Note: There is a 25% interest rate on all loans.)");
            decimal amount = Utility.ReadDec();
            if (UICheckForCommands(amount))
            {
                return;
            }
            if (amount > 0)
            {
                currentCustomer.AddLoan(amount);
                Loan newLoan = currentCustomer.Loans[currentCustomer.Loans.Count - 1];
                Console.WriteLine($"New loan #{newLoan.LoanID} taken in the amount of {newLoan.Principal}.\n" +
                    $"You will need to pay us back in the amount of {newLoan.Balance}." +
                    $"\nPress Enter to return to the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
            else
            {
                Console.WriteLine("That is not a valid amount.\nPress Enter to try again.");
                Console.ReadLine();
                menu = TakeLoan;
                return;
            }
        }
        private void MakeTermDeposit()
        {
            Console.WriteLine(HelpMessage + "\n\n");
            Console.WriteLine($"How much would you like to save?");
            decimal amount = Utility.ReadDec();
            if (UICheckForCommands(amount))
            {
                return;
            }
            if (amount > 0)
            {
                Console.WriteLine("How many years would you like to save it for?");
                int termYears = Utility.ReadInt();
                if (UICheckForCommands(termYears))
                {
                    return;
                }

                //Simulate days since creation
                Console.WriteLine("Please enter the date this was created in the following format: YYYY-MM-DD");
                string dateString = Utility.ReadString();
                if (UICheckForCommands(dateString))
                {
                    return;
                }
                DateTime creationDate;
                try
                {
                    creationDate = Convert.ToDateTime(dateString);
                    TermDeposit newTD = new TermDeposit
                    {
                        Amount = amount,
                        TermYears = termYears,
                        DateCreated = creationDate
                    };
                    Console.WriteLine($"New Term Deposit #{newTD.TDID} made in the amount of {amount}." +
                        $"\nIn {newTD.TermYears} year(s) it will be ready for withdrawl in the " +
                        $"amount of {newTD.withdrawlAmount}.\nPress Enter to return to the main menu.");
                    menu = MainMenu;
                }
                catch
                {
                    Console.WriteLine("That doesn't look like a date. Please press enter to try again.");
                    menu = MakeTermDeposit;
                }
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("That is not a valid amount..\nPress Enter to return to try again.");
                Console.ReadLine();
                menu = MakeTermDeposit;
                return;
            }
        }
        private void PayLoan()
        {
            if (currentCustomer.Loans.Count > 0)
            {
                Console.WriteLine(HelpMessage + "\n\n");
                Console.WriteLine("Which loan would like to make a payment on?");
                int loanID = Utility.ReadInt();
                if (UICheckForCommands(loanID))
                {
                    return;
                }
                if (bank.confirmLoanOwnership(currentCustomerID, loanID))
                {
                    Loan loan = currentCustomer.findLoanByID(loanID);
                    if (!loan.PaidOff)
                    {
                        Console.WriteLine("Would you like to:\n" +
                        "A: pay with cash or\n" +
                        "B: pay from one of your other accounts?");
                        string input = Utility.ReadString();
                        if (UICheckForCommands(input))
                        {
                            return;
                        }
                        switch (input)
                        {
                            case "a":
                            case "A":
                                {
                                    Console.WriteLine("How much would like to pay off?");
                                    decimal amount = Utility.ReadDec();
                                    if (UICheckForCommands(amount))
                                    {
                                        return;
                                    }
                                    if (amount > 0)
                                    {
                                        Console.WriteLine($"Paying {amount}...");
                                        loan.PayAmount(amount);
                                        Console.WriteLine($"Paid {amount}.\n");
                                        PrintLoan(loan);
                                        menu = MainMenu;
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That is not a valid amount.\nPress Enter to try again.");
                                        Console.ReadLine();
                                        menu = PayLoan;
                                        return;
                                    }
                                }
                            case "b":
                            case "B":
                                {
                                    Console.WriteLine("Your Accounts");
                                    PrintAccounts();
                                    Console.WriteLine("Which account would you like to make a payment from?");
                                    int payAcctID = Utility.ReadInt();
                                    if (UICheckForCommands(payAcctID))
                                    {
                                        return;
                                    }
                                    if (bank.confirmAccountOwnership(currentCustomer.CustomerID, payAcctID))
                                    {
                                        Account payAcct = currentCustomer.findAccountByID(payAcctID);
                                        Console.WriteLine("How much would like to pay off?");
                                        decimal amount = Utility.ReadDec();
                                        if (UICheckForCommands(amount))
                                        {
                                            return;
                                        }
                                        if (amount > 0)
                                        {
                                            if (amount <= payAcct.Balance)
                                            {
                                                Console.WriteLine($"Paying {amount}...");
                                                payAcct.WithdrawToLoan(loanID, amount);
                                                loan.PayAmount(amount);
                                                Console.WriteLine($"Paid {amount} from account #{payAcctID}.");
                                                PrintLoan(loan);
                                                Console.WriteLine("Press Enter to return to the main menu.");
                                                Console.ReadLine();
                                                menu = MainMenu;
                                                return;
                                            }
                                            else
                                            {
                                                Console.WriteLine("You incur a negative balance in paying off a loan.\n" +
                                                    "Press Enter to try again.");
                                                Console.ReadLine();
                                                menu = PayLoan;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("That is not a valid amount.\nPress Enter to try again.");
                                            Console.ReadLine();
                                            menu = PayLoan;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (payAcctID > 0)
                                        {
                                            Console.WriteLine("That is not one of your accounts.\nPress Enter to try again.");
                                            Console.ReadLine();
                                            menu = PayLoan;
                                            return;
                                        }
                                        else
                                        {
                                            Console.WriteLine("That isn't a valid account ID\nPress Enter to try again.");
                                            Console.ReadLine();
                                            menu = PayLoan;
                                            return;
                                        }
                                    }
                                }
                            default:
                                {
                                    Console.WriteLine("Please enter on of the available options.\nPress Enter to try again.");
                                    Console.ReadLine();
                                    menu = PayLoan;
                                    return;
                                }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That loan is paid off. No further action is needed\n" +
                            "Press Enter to return to the main menu");
                        Console.ReadLine();
                        menu = MainMenu;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("That's not one of your loans.\nPress Enter to try again.");
                    Console.ReadLine();
                    menu = PayLoan;
                    return;
                }
            }
            else
            {
                Console.WriteLine("You don't have any loans.\nPress Enter to return to the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void TermDepositWithdraw()
        {
            if (currentCustomer.TermDeposits.Count > 0)
            {
                Console.WriteLine(HelpMessage + "\n\n");
                Console.WriteLine("Which Term Deposit would like to make withdraw?");
                int TDID = Utility.ReadInt();
                if (UICheckForCommands(TDID))
                {
                    return;
                }
                if (bank.confirmTDOwnership(currentCustomerID, TDID))
                {
                    TermDeposit TermD = currentCustomer.findTDByID(TDID);
                    Console.WriteLine("Would you like to:\n" +
                        "A: Receive payment in cash or\n" +
                        "B: transfer to one of your other accounts?");
                    string input = Utility.ReadString();
                    if (UICheckForCommands(input))
                    {
                        return;
                    }
                    switch (input)
                    {
                        case "a":
                        case "A":
                            {
                                if (TermD.MaturityCheck())
                                {
                                    Console.WriteLine($"Withdrawing full amount...");
                                    TermD.withdraw();
                                    Console.WriteLine($"Withdrew full amount.");
                                    Console.WriteLine("Press Enter to return to the main menu.");
                                    Console.ReadLine();
                                    menu = MainMenu;
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("That loan has not reached maturity yet.\n" +
                                        "Press Enter to choose another term deposit.");
                                    Console.ReadLine();
                                    menu = TermDepositWithdraw;
                                    return;
                                }
                            }
                        case "b":
                        case "B":
                            {
                                Console.WriteLine("Your Accounts");
                                PrintAccounts();
                                Console.WriteLine("Which account would you like to make a payment from?");
                                int toAcctID = Utility.ReadInt();
                                if (UICheckForCommands(toAcctID))
                                {
                                    return;
                                }
                                if (bank.confirmAccountOwnership(currentCustomer.CustomerID, toAcctID))
                                {
                                    Account toAcct = currentCustomer.findAccountByID(toAcctID);
                                    Console.WriteLine($"Withdrawing full amount (${TermD.Amount}) to account #{toAcctID}...");
                                    toAcct.DepositFromTermDeposit(TermD.TDID, TermD.Amount);
                                    TermD.withdraw();
                                    Console.WriteLine($"Withdrew full amount (${TermD.Amount}) to account #{toAcctID}");
                                    Console.WriteLine("Press Enter to return to the main menu.");
                                    Console.ReadLine();
                                    menu = MainMenu;
                                    return;
                                }
                                else
                                {
                                    if (toAcctID > 0)
                                    {
                                        Console.WriteLine("That is not one of your accounts.\nPress Enter to try again.");
                                        Console.ReadLine();
                                        menu = TermDepositWithdraw;
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That isn't a valid account ID\nPress Enter to try again.");
                                        Console.ReadLine();
                                        menu = TermDepositWithdraw;
                                        return;
                                    }
                                }
                            }
                        default:
                            {
                                Console.WriteLine("Please enter on of the available options.\nPress Enter to try again.");
                                Console.ReadLine();
                                menu = TermDepositWithdraw;
                                return;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("That's not one of your Term Deposits.\nPress Enter to return to try again.");
                    Console.ReadLine();
                    menu = TermDepositWithdraw;
                    return;
                }
            }
            else
            {
                Console.WriteLine("You don't have any Term Deposits.\nPress Enter to return to the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void TransactionHistory()
        {
            if (currentCustomer.TotalNumAccts > 0)
            {
                Console.WriteLine(HelpMessage + "\n\n");
                Console.WriteLine("Your Accounts");
                PrintAccounts();
                Console.WriteLine("Which account would you like to look at?");
                int acctID = Utility.ReadInt();
                if (UICheckForCommands(acctID))
                {
                    return;
                }
                if (bank.confirmAccountOwnership(currentCustomer.CustomerID, acctID))
                {
                    ListTransactions(currentCustomer.findAccountByID(acctID));
                    Console.WriteLine("\nPress Enter to return to the main menu.");
                    Console.ReadLine();
                    menu = MainMenu;
                    return;
                }
                else
                {
                    if (acctID > 0)
                    {
                        Console.WriteLine("That is not one of your accounts.\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = TransactionHistory;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That isn't a valid account ID\nPress Enter to try again.");
                        Console.ReadLine();
                        menu = TransactionHistory;
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need at least one account to be able check it's transaction history.\n" +
                    "Press Enter to return to the main menu.");
                Console.ReadLine();
                menu = MainMenu;
                return;
            }
        }
        private void LogOut()
        {
            Console.WriteLine("Logging Out. Thank you for using CBASS.\nPress Enter to continue.");
            Console.ReadLine();
            menu = StartUp;
            return;
        }
        private void Exit()
        {
            Console.WriteLine("Thank you for using CBASS. Hit Enter to close the application.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        private void PrintAccount(Account acct)
        {
            if (acct.isDeleted)
            {
                Console.Write("(Deleted) ");
            }
            Console.Write($"Account ID #{acct.AccountID} ");
            Console.WriteLine($"  :  Type: {acct.AccountType()}");
            Console.Write($"Current Balance: ${acct.Balance}");
            if (acct.Balance < 0)
            {
                Console.Write($" (Including current overdraft fees of ${((BusinessAccount)acct).overdraftFees})");
            }
            Console.WriteLine();
        }
        private void PrintAccounts()
        {
            Console.WriteLine("***Business Accounts***");
            foreach (BusinessAccount BA in currentCustomer.BAccounts)
            {
                if (!BA.isDeleted)
                {
                    PrintAccount(BA);
                }
            }
            Console.WriteLine("***Checking Accounts***");
            foreach (CheckingAccount CA in currentCustomer.CAccounts)
            {
                if (!CA.isDeleted)
                {
                    PrintAccount(CA);
                }
            }
        }
        private void PrintLoan(Loan loan)
        {
            Console.Write($"Term Deposit ID #{loan.LoanID}  :  ");
            Console.WriteLine($"Principal Amount: ${loan.Principal}");
            Console.Write($"Remaining Balance: ${loan.Balance}");
            if (loan.PaidOff)
            {
                Console.Write($"  :  Paid off.");
            }
            Console.WriteLine();
        }
        private void PrintTD(TermDeposit termD)
        {
            Console.WriteLine($"Account ID #{termD.TDID}  : ");
            Console.WriteLine($"Current Amount: ${termD.Amount}");
            if (termD.MaturityCheck())
            {
                Console.WriteLine($"  :  Ready to be withdrawn.");
            }
        }
        private void Summary(Customer customer)
        {
            Console.WriteLine("***Business Accounts***");
            foreach (BusinessAccount BA in customer.BAccounts)
            {
                PrintAccount(BA);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("***Checking Accounts***");
            foreach (CheckingAccount CA in customer.CAccounts)
            {
                PrintAccount(CA);
            }
            Console.WriteLine();
            Console.WriteLine("***Loans***");
            foreach (Loan loan in customer.Loans)
            {
                PrintLoan(loan);
            }
            Console.WriteLine();
            Console.WriteLine("***Term Deposits***");
            foreach (TermDeposit TD in customer.TermDeposits)
            {
                PrintTD(TD);
            }
        }
        private void ListTransactions(Account acct)
        {
            Console.WriteLine($"Transactions for Account #{acct.AccountID}");
            foreach (var trans in acct.transactions)
            {
                PrintTransaction(trans);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private void PrintTransaction(Transaction trans)
        {
            Console.WriteLine($"Transaction Date & Time: {trans.TransTime}");
            Console.WriteLine($"Type: {trans.Type()}");
            if (trans.Type() == TransactionType.TransferIn)
            {
                Console.WriteLine($"Transferred from Account #{((TransferIn)trans).AccountIDFrom}");
            }
            else if (trans.Type() == TransactionType.TransferOut)
            {
                Console.WriteLine($"Transferred to Account #{((TransferOut)trans).AccountIDTo}");
            }
            else
                Console.WriteLine($"Amount: ${trans.Amount}");
            Console.WriteLine();
        }
        private bool UICheckForCommands(string s)
        {
            if (s == Utility.ExitCode.ToString())
            {
                menu = Exit;
                return true;
            }
            else if (s == Utility.ExitCode.ToString())
            {
                menu = MainMenu;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UICheckForCommands(int i)
        {
            if (i == Utility.ExitCode)
            {
                menu = Exit;
                return true;
            }
            else if (i == Utility.MainCode)
            {
                menu = MainMenu;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UICheckForCommands(decimal d)
        {
            if (d == Convert.ToDecimal(Utility.ExitCode))
            {
                menu = Exit;
                return true;
            }
            else if (d == Convert.ToDecimal(Utility.MainCode))
            {
                menu = MainMenu;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}