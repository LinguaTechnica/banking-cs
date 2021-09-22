namespace BankApp.Accounts
{
    public class SavingsAccount: Account
    {
        public SavingsAccount(Customer customer)
        {
            Customer = customer;
            InterestRate = 0.03m;
        }
    }
}