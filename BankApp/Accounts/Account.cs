using System;

namespace BankApp.Accounts
{
    public abstract class Account
    {
        private decimal _balance;
        protected decimal InterestRate;
        public Customer Customer;
        public Decimal Balance => _balance;

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            _balance -= amount;
        }

        public decimal Forecast(int numberOfYears)
        {
            return decimal.Round(CalculateAnnualInterest() * numberOfYears, 2);
        }

        private decimal CalculateAnnualInterest()
        {
            return Balance + (Balance * InterestRate);
        }
    }
}