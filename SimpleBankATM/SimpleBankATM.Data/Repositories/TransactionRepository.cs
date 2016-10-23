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
        public Transaction CreateTransaction(Transaction Transaction)
        {
            _dataContext.Transactions.Add(Transaction);
            _dataContext.SaveChanges();
            return Transaction;
        }

        //Update
        public Transaction UpdateTransaction(Transaction Transaction)
        {
            _dataContext.SetModified(Transaction);
            _dataContext.SaveChanges();
            return _dataContext.Transactions.FirstOrDefault(_ => _.TransactionId == Transaction.TransactionId);
        }

        //Delete
        public bool DeleteTransaction(int TransactionId)
        {
            var Transaction = _dataContext.Transactions.FirstOrDefault(_ => _.TransactionId == TransactionId);
            if (Transaction == null)
            {
                return false;
            }
            try
            {
                Transaction.Deleted = DateTime.Now;
                _dataContext.SetModified(Transaction);

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