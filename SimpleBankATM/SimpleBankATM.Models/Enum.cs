namespace SimpleBankATM.Models
{
    public enum TransactionType : int
    {
        Deposit = 1,
        Withdrawl = 2
    }

    public enum AccountType : int
    {
        Checking = 1,
        Savings = 2
    }
}