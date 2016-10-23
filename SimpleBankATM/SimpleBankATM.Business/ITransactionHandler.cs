using SimpleBankATM.Models;

namespace SimpleBankATM.Business
{
    public interface ITransactionHandler
    {
        TransactionStatus IsValidTransaction(Transaction transaction, TransactionType transactionType);
        TransactionStatus IsValidUpdateTransaction(Transaction transaction, TransactionType transactionType);
    }
}