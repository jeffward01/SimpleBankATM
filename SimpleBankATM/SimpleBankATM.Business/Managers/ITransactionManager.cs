using SimpleBankATM.Models;
using System.Collections.Generic;

namespace SimpleBankATM.Business.Managers
{
    public interface ITransactionManager
    {
        TransactionStatus AddTransaction(int transactionAmount, int accountId, TransactionType transactionType);

        Transaction GetTransactionByTransactionId(int transactionId);

        IList<Transaction> GetAllTransactions();

        bool DeleteTransaction(int transactionId);

        TransactionStatus UpdateTransaction(Transaction transaction, TransactionType transactionType);
    }
}