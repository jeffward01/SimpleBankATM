using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;

namespace SimpleBankATM.Business.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountManager(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }

        public Account AddAccount(int customerId)
        {
            var newAccount = GenerateAccountInformation(customerId);
            return _AccountRepository.CreateAccount(newAccount);
        }

        public Account GetAccountByAccountId(int AccountId)
        {
            return _AccountRepository.GetAccountById(AccountId);
        }

        public IList<Account> GetAllAccountsForCustomerId(int customerId)
        {
            return _AccountRepository.GetAllAccountsForCustomerId(customerId);
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

        private Account GenerateAccountInformation(int customerId)
        {
            var newAccount = new Account();
            newAccount.CustomerId = customerId;
            newAccount.RoutingNumber = LocalBankInformation.RoutingNumber;
            newAccount.AccountNumber = GenerateAccountNumber();
            return newAccount;
        }

        private string GenerateAccountNumber()
        {
            var accountNumber = GenerateNumber();
           // while (_AccountRepository.DoesAccountNumberExist(accountNumber))
          //  {
          //      accountNumber = GenerateNumber();
          //  }
            return accountNumber;
        }

        public string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }
    }
}