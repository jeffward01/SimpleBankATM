using SimpleBankATM.Models;
using System;
using System.Data.Entity;

namespace SimpleBankATM.Data.Infrastructure
{
    public interface IDataContext : IDisposable
    {
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Transaction> Transactions { get; set; }
        DbSet<Account> Accounts { get; set; }

        int SaveChanges();

        void SetModified(object entity);
    }
}