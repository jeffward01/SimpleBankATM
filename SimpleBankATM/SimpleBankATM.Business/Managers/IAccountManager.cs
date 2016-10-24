using SimpleBankATM.Models;
using System.Collections.Generic;

namespace SimpleBankATM.Business.Managers
{
    public interface IAccountManager
    {
        Account AddAccount(int customerId, AccountType accountType);

        Account GetAccountByAccountId(int AccountId);

        Account GetAccountByAccountNumber(string accountNumber);

        IList<Account> GetAllAccounts();

        IList<Account> GetAllAccountsForCustomerId(int customerId);

        bool DeleteAccount(int accountId);

        bool DeleteAccount(string accountNumber);

        Account UpdateAccount(Account Account);

        string GenerateNumber();
    }
}