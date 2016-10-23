using System.Collections.Generic;
using SimpleBankATM.Models;

namespace SimpleBankATM.Data.Repositories
{
    public interface ITransactionRepository
    {
        IList<Transaction> GetAllTransaction();
        Transaction GetTransactionById(int transactionId);
        Transaction CreateTransaction(Transaction Transaction);
        Transaction UpdateTransaction(Transaction Transaction);
        bool DeleteTransaction(int TransactionId);
    }
}