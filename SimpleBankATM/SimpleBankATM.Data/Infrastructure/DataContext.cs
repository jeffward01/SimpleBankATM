using Microsoft.AspNet.Identity.EntityFramework;
using NLog;
using SimpleBankATM.Models;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models.LookupModels;

namespace SimpleBankATM.Data.Infrastructure
{
    using AccountDataConfig = System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Account>;
    using TransactionDataConfig = System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Transaction>;
    using UserDatConfig = System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Customer>;
    using LU_AccountTypeonfig = System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<LU_AccountType>;


    public class DataContext : DbContext, IDataContext //IdentityDbContext<IdentityUser>,
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
                Logger.Debug("An Error occured trying to connect to the database " + e.ToString());
            }
        }

        public IDbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
        //Code First

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //UserProfile
            UserDatConfig user = modelBuilder.Entity<Customer>();
            user.HasKey(a => a.CustomerId);
            user.HasMany(u => u.Accounts).WithRequired().HasForeignKey(rc => rc.CustomerId);
            user.Ignore(_ => _.FullName);
         

            AccountDataConfig adc = modelBuilder.Entity<Account>();
            adc.HasKey(_ => _.AccountId);
            adc.HasMany(_ => _.Transactions).WithRequired().HasForeignKey(x => x.AccountId);
            adc.HasRequired(_ => _.AccountType).WithMany().HasForeignKey(x => x.AccountTypeId).WillCascadeOnDelete(false);


            TransactionDataConfig tdc = modelBuilder.Entity<Transaction>();
            tdc.HasKey(_ => _.TransactionId);
            tdc.HasRequired(_ => _.TransactionType).WithMany().HasForeignKey(x => x.TransactionTypeId).WillCascadeOnDelete(false);

            LU_AccountTypeonfig at = modelBuilder.Entity<LU_AccountType>();
            at.HasKey(_ => _.AccountTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}