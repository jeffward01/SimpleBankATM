using SimpleBankATM.Models;

namespace SimpleBankATM.Business
{
    public class TransactionHandler : ITransactionHandler
    {
        public TransactionStatus IsValidTransaction(Transaction transaction, TransactionType transactionType)
        {
            var transactionValidator = new TransactionValidator(transaction, transactionType);
            return transactionValidator.IsValidTransaction();
        }

        public TransactionStatus IsValidUpdateTransaction(Transaction transaction, TransactionType transactionType)
        {
            var transactionValidator = new TransactionValidator(transaction, transactionType);
            return transactionValidator.IsValidUpdateTransaction();
        }
    }
}