using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankATM.Models;

namespace SimpleBankATM.Data.Infrastructure
{
    public interface IDataContext : IDisposable
    {

        IDbSet<User> Users { get; set; }
        IDbSet<Transaction> Transactions { get; set; }
        IDbSet<Account> Accounts { get; set; }
             
        int SaveChanges();
    }
}
