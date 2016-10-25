using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;

namespace SimpleBankATM.Business
{
    public class TransactionHandler : ITransactionHandler
    {
        private IAccountRepository _accountRepository { get; set; }
        private ITransactionRepository _transactionRepository { get; set; }

        public TransactionHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public TransactionStatus IsValidTransaction(Transaction transaction, TransactionType transactionType)
        {
            var transactionValidator = new TransactionValidator(transaction, transactionType, _transactionRepository, _accountRepository);
            return transactionValidator.IsValidTransaction();
        }

        public TransactionStatus IsValidUpdateTransaction(Transaction transaction, TransactionType transactionType)
        {
            var transactionValidator = new TransactionValidator(transaction, transactionType, _transactionRepository, _accountRepository);
            return transactionValidator.IsValidUpdateTransaction();
        }
    }
}