using SimpleBankATM.Models;
using System.Collections.Generic;

namespace SimpleBankATM.Data.Repositories
{
    public interface IAccountRepository
    {
        IList<Account> GetAllAccounts();

        Account GetAccountById(int accountId);

        Account GetAccountByAccountNumber(string accountNumber);

        Account CreateAccount(Account account);

        IList<Account> GetAllAccountsForCustomerId(int customerId);

        Account UpdateAccount(Account account);

        bool DeleteAccount(int accountId);

        string GetAccountIdByAccountNumber(string accountNumber);

        bool DoesAccountNumberExist(string accountNumber);

        bool DeleteAccountByAccountNumber(string accountNumber);
    }
}