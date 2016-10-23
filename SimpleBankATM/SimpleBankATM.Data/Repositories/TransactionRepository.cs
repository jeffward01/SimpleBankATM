using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankATM.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        public IList<Transaction> GetAllTransaction()
        {
            using (var context = new DataContext())
            {
                return context.Transactions.Where(_ => _.Deleted == null).ToList();
            }
        }

        public Transaction GetTransactionById(int transactionId)
        {
            using (var context = new DataContext())
            {
                return context.Transactions.FirstOrDefault(_ => _.TransactionId == transactionId);
            }
        }

        public IList<Transaction> GetAllTransactionsForAccountId(int accountId)
        {
            using (var context = new DataContext())
            {
                return context.Transactions.Where(_ => _.Deleted == null && _.AccountId == accountId).ToList();
            }
        }

        //Create
        public Transaction CreateTransaction(Transaction transaction)
        {
            using (var context = new DataContext())
            {
                context.Transactions.Add(transaction);
                context.SaveChanges();
                return transaction;
            }
        }

        //Update
        public Transaction UpdateTransaction(Transaction transaction)
        {
            using (var context = new DataContext())
            {
                context.SetModified(transaction);
                context.SaveChanges();
                return context.Transactions.FirstOrDefault(_ => _.TransactionId == transaction.TransactionId);
            }
        }

        //Delete
        public bool DeleteTransaction(int transactionId)
        {
            using (var context = new DataContext())
            {
                var transaction = context.Transactions.FirstOrDefault(_ => _.TransactionId == transactionId);
                if (transaction == null)
                {
                    return false;
                }
                try
                {
                    transaction.Deleted = DateTime.Now;
                    context.SetModified(transaction);

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