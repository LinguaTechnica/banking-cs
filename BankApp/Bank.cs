using System;
using System.Collections.Generic;
using System.Net.Security;
using BankApp.Accounts;

namespace BankApp
{
    public class Bank
    {
        public bool SessionActive = true;
        public Tuple<bool, Account> UserActive;
        public List<Account> Accounts;

        public Bank()
        {
            // Added user to list for testing purposes only. Not required.
            Accounts = new List<Account> { new SavingsAccount(new Customer("Kay")) };
            UserActive = new Tuple<bool, Account>(false, null);
        }

        public void RunTerminal()
        {
            while (SessionActive)
            {
                Console.WriteLine("\t1 - View account\n\t2 - Create new account\n\t3 - Quit");
                TerminalOption userChoice = (TerminalOption)Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case TerminalOption.ViewAccount:
                    {
                        Console.WriteLine("Enter your name: ");
                        var credentials = Console.ReadLine();
                        var account = GetAccount(credentials);
                        if (account != null)
                        {
                            UserActive = new Tuple<bool, Account>(true, account);
                            ShowUserAccount(account);
                        }

                        break;
                    }
                    case TerminalOption.CreateAccount:
                        CreateAccount();
                        break;
                    case TerminalOption.Quit:
                        Console.WriteLine("Thanks for being a customer! Have a nice day!");
                        SessionActive = false;
                        break;
                    default:
                        Console.WriteLine("Please choose from our options.");
                        break;
                }

            }
        }

        private Account GetAccount(string customerName)
        {
            return Accounts.Find(account => account.Customer.Name == customerName);
        }

        private void ShowUserAccount(Account account)
        {
            while (UserActive.Item1)
            {
                
                Console.WriteLine($"Current Balance: {account.Balance}\n\n");
                Console.WriteLine("What would you like to do?\n\t> (D)eposit\n\t> (W)ithdraw\n\t> (F)orecast\n\t> (R)eturn\n");
                var userChoice = Console.ReadLine();

                if (userChoice.Equals("D"))
                {
                    Console.WriteLine("Enter deposit amount: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    account.Deposit(amount);
                } else if (userChoice.Equals("W"))
                {
                    Console.WriteLine("Enter withdrawal amount: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    account.Withdraw(amount);
                } else if (userChoice.Equals("F"))
                {
                    Console.WriteLine("Enter forecast years: ");
                    int years = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(account.Forecast(years));
                }
                else
                {
                    UserActive = new Tuple<bool, Account>(false, null);
                }
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("What is the name for the account?");
            var username = Console.ReadLine();
            Customer customer = new Customer(username);
            
            Console.WriteLine("What type of account would you like to create?");
            Console.Write("\n\t(C)hecking\n\t(S)avings\n");
            Account newAccount;
            var choice = Console.ReadLine();
            
            if (choice.Equals("C"))
            {
                newAccount = new CheckingAccount(customer);
                UserActive = new Tuple<bool, Account>(true, newAccount);
                ShowUserAccount(newAccount);
            } else if (choice.Equals("S"))
            {
                newAccount = new SavingsAccount(customer);
                UserActive = new Tuple<bool, Account>(true, newAccount);
                ShowUserAccount(newAccount);
            }
            else
            {
                Console.WriteLine("\nOnly checking or savings are available at this time.");
            }
        }
    }
}