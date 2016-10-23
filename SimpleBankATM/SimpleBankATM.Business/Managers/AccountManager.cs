using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System.Collections.Generic;

namespace SimpleBankATM.Business.Managers
{
    public class AccountManager
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountManager(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }

        public Account AddAccount(Account Account)
        {
            return _AccountRepository.CreateAccount(Account);
        }

        public Account GetAccountByAccountId(int AccountId)
        {
            return _AccountRepository.GetAccountById(AccountId);
        }

        public Account GetAccountByAccountNumber(string accountNumber)
        {
            return _AccountRepository.GetAccountByAccountNumber(accountNumber);
        }

        public IList<Account> GetAllAccounts()
        {
            return _AccountRepository.GetAllAccounts();
        }

        public bool DeleteAccount(int accountId)
        {
            return _AccountRepository.DeleteAccount(accountId);
        }

        public bool DeleteAccount(string accountNumber)
        {
            return _AccountRepository.DeleteAccountByAccountNumber(accountNumber);
        }

        public Account UpdateAccount(Account Account)
        {
            return _AccountRepository.UpdateAccount(Account);
        }
    }
}