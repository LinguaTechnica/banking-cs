using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            Console.WriteLine("Welcome to Local Bank! How can I help you today?");
            bank.RunTerminal();
        }

    }
}