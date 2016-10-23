using SimpleBankATM.Models;

namespace SimpleBankATM.Business
{
    public static class TransactionHandler
    {
        public static TransactionStatus IsValid(int count, int accountId, TransactionType transactionType)
        {
            var transactionValidator = new TransactionValidator(count, accountId, transactionType);
            return transactionValidator.isValidTransaction();
        }
    }
}