using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankATM.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        //GetAll
        public IList<Account> GetAllAccounts()
        {
            using (var context = new DataContext())
            {
                return context.Accounts.Where(_ => _.Deleted == null).ToList();
            }
        }

        //GetById
        public Account GetAccountById(int accountId)
        {
            using (var context = new DataContext())
            {
                return context.Accounts.FirstOrDefault(_ => _.AccountId == accountId);
            }
        }

        public Account GetAccountByAccountNumber(string accountNumber)
        {
            using (var context = new DataContext())
            {
                return context.Accounts.FirstOrDefault(_ => _.AccountNumber == accountNumber);
            }
        }

        public string GetAccountIdByAccountNumber(string accountNumber)
        {
            using (var context = new DataContext())
            {
                return context.Accounts.FirstOrDefault(_ => _.AccountNumber == accountNumber).AccountNumber;
            }
        }

        public IList<Account> GetAllAccountsForCustomerId(int customerId)
        {
            using (var context = new DataContext())
            {
                return context.Accounts.Where(_ => _.Deleted == null && _.CustomerId == customerId).ToList();
            }
        }

        public bool DoesAccountNumberExist(string accountNumber)
        {
            using (var context = new DataContext())
            {
                var account = context.Accounts.FirstOrDefault(_ => _.AccountNumber == accountNumber);
                if (account == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Create
        public Account CreateAccount(Account account)
        {
            using (var context = new DataContext())

            {
                context.Accounts.Add(account);
                context.SaveChanges();
                return account;
            }
        }

        //Update
        public Account UpdateAccount(Account account)
        {
            using (var context = new DataContext())
            {
                context.SetModified(account);
                context.SaveChanges();
                return context.Accounts.FirstOrDefault(_ => _.AccountId == account.AccountId);
            }
        }

        //Delete
        public bool DeleteAccount(Account account)
        {
            using (var context = new DataContext())
            {
                try
                {
                    account.Deleted = DateTime.Now;
                    context.SetModified(account);

                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}