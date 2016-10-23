using Microsoft.AspNet.Identity.EntityFramework;
using NLog;
using SimpleBankATM.Models;
using System;
using System.ComponentModel;
using System.Data.Entity;
using SimpleBankATM.Data.Infrastructure;

namespace SimpleBankATM.Data.Infrastructure
{
    using AccountDataConfig = System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Account>;
    using TransactionDataConfig = System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Transaction>;
    using UserDatConfig = System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>;

    public class DataContext : IdentityDbContext<IdentityUser>, IDataContext
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DataContext() : base("DataContext")
        {
            try
            {
            }
            catch (Exception e)
            {
                Logger.Debug("_____CRTIICAL ERROR_____________");
                Logger.Debug("An Error occured trying to connect to the dayabase " + e.ToString());
            }
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
        //Code First

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //UserProfile
            UserDatConfig user = modelBuilder.Entity<User>();
            user.HasKey(a => a.UserId);
            user.HasMany(u => u.Accounts).WithRequired().HasForeignKey(rc => rc.UserId);
            user.Ignore(_ => _.FullName);
            user.Ignore(_ => _.NoOfAccounts);
            user.Ignore(_ => _.TotalBalence);

            AccountDataConfig adc = modelBuilder.Entity<Account>();
            adc.HasKey(_ => _.AccountId);
            adc.HasMany(_ => _.Transactions).WithRequired().HasForeignKey(x => x.AccountId);

            TransactionDataConfig tdc = modelBuilder.Entity<Transaction>();
            tdc.HasKey(_ => _.TransactionId);
            tdc.HasRequired(_ => _.TransactionType).WithMany().HasForeignKey(x => x.TransactionTypeId).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}