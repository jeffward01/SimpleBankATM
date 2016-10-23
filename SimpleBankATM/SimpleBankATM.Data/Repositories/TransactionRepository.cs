using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankATM.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDataContext _dataContext = new DataContext();

        public IList<Transaction> GetAllTransaction()
        {
            return _dataContext.Transactions.Where(_ => _.Deleted == null).ToList();
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return _dataContext.Transactions.FirstOrDefault(_ => _.TransactionId == transactionId);
        }

        public IList<Transaction> GetAllTransactionsForAccountId(int accountId)
        {
            return _dataContext.Transactions.Where(_ => _.Deleted == null && _.AccountId == accountId).ToList();
        }

        //Create
        public Transaction CreateTransaction(Transaction transaction)
        {
            _dataContext.Transactions.Add(transaction);
            _dataContext.SaveChanges();
            return transaction;
        }

        //Update
        public Transaction UpdateTransaction(Transaction transaction)
        {
            _dataContext.SetModified(transaction);
            _dataContext.SaveChanges();
            return _dataContext.Transactions.FirstOrDefault(_ => _.TransactionId == transaction.TransactionId);
        }

        //Delete
        public bool DeleteTransaction(int transactionId)
        {
            var transaction = _dataContext.Transactions.FirstOrDefault(_ => _.TransactionId == transactionId);
            if (transaction == null)
            {
                return false;
            }
            try
            {
                transaction.Deleted = DateTime.Now;
                _dataContext.SetModified(transaction);

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