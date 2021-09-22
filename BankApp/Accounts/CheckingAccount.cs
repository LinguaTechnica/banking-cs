namespace BankApp.Accounts
{
    public class CheckingAccount: Account
    {
        public CheckingAccount(Customer customer)
        {
            Customer = customer;
            InterestRate = 0.0025m;
        }
    }
}