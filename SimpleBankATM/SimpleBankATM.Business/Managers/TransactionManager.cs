using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System.Collections.Generic;

namespace SimpleBankATM.Business.Managers
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ITransactionRepository _transactionRepository;

        private readonly ITransactionHandler _transactionHandler;

        public TransactionManager(ITransactionRepository transactionRepository, ITransactionHandler transactionHandler)
        {
            _transactionRepository = transactionRepository;
            _transactionHandler = transactionHandler;
        }

        public TransactionStatus AddTransaction(int transactionAmount, int accountId, TransactionType transactionType)
        {
            var transaction = CreateTransaction(transactionAmount, accountId, transactionType);
            return _transactionHandler.IsValidTransaction(transaction, transactionType);
        }

        public Transaction GetTransactionByTransactionId(int transactionId)
        {
            return _transactionRepository.GetTransactionById(transactionId);
        }

        public IList<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransaction();
        }

        public bool DeleteTransaction(int transactionId)
        {
            return _transactionRepository.DeleteTransaction(transactionId);
        }

        public TransactionStatus UpdateTransaction(Transaction transaction, TransactionType transactionType)
        {
            return _transactionHandler.IsValidUpdateTransaction(transaction, transactionType);
        }

        private Transaction CreateTransaction(int transactionAmount, int accountId, TransactionType transactionType)
        {
            var newTransaction = new Transaction();
            newTransaction.AccountId = accountId;
            newTransaction.TransactionAmount = transactionAmount;
            newTransaction.TransactionTypeId = (int) transactionType;
            return newTransaction;
        }
    }
}