using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankATM.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDataContext _dataContext = new DataContext();

        //GetAll
        public IList<Account> GetAllAccounts()
        {
            return _dataContext.Accounts.Where(_ => _.Deleted == null).ToList();
        }

        //GetById
        public Account GetAccountById(int accountId)
        {
            return _dataContext.Accounts.FirstOrDefault(_ => _.AccountId == accountId);
        }

        public Account GetAccountByAccountNumber(string accountNumber)
        {
            return _dataContext.Accounts.FirstOrDefault(_ => _.AccountNumber == accountNumber);
        }

        public string GetAccountIdByAccountNumber(string accountNumber)
        {
            return _dataContext.Accounts.FirstOrDefault(_ => _.AccountNumber == accountNumber).AccountNumber;
        }

        public IList<Account> GetAllAccountsForCustomerId(int customerId)
        {
            return _dataContext.Accounts.Where(_ => _.Deleted == null && _.CustomerId == customerId).ToList();
        }

        //Create
        public Account CreateAccount(Account account)
        {
            _dataContext.Accounts.Add(account);
            _dataContext.SaveChanges();
            return account;
        }

        //Update
        public Account UpdateAccount(Account account)
        {
            _dataContext.SetModified(account);
            _dataContext.SaveChanges();
            return _dataContext.Accounts.FirstOrDefault(_ => _.AccountId == account.AccountId);
        }

        //Delete
        public bool DeleteAccount(int accountId)
        {
            var account = _dataContext.Accounts.FirstOrDefault(_ => _.AccountId == accountId);
            if (account == null)
            {
                return false;
            }
            try
            {
                account.Deleted = DateTime.Now;
                _dataContext.SetModified(account);

                _dataContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteAccountByAccountNumber(string accountNumber)
        {
            var account = _dataContext.Accounts.FirstOrDefault(_ => _.AccountNumber == accountNumber);
            if (account == null)
            {
                return false;
            }
            try
            {
                account.Deleted = DateTime.Now;
                _dataContext.SetModified(account);

                _dataContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}