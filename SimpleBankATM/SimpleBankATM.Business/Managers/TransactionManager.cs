using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;

namespace SimpleBankATM.Business.Managers
{
   public class TransactionManager
    {
        private readonly ITransactionRepository _TransactionRepository;

        public TransactionManager(ITransactionRepository TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;
        }

        public Transaction AddTransaction(Transaction Transaction)
        {
            return _TransactionRepository.CreateTransaction(Transaction);
        }

        public Transaction GetTransactionByTransactionId(int TransactionId)
        {
            return _TransactionRepository.GetTransactionById(TransactionId);
        }

        public IList<Transaction> GetAllTransactions()
        {
            return _TransactionRepository.GetAllTransaction();
        }

        public bool DeleteTransaction(int TransactionId)
        {
            return _TransactionRepository.DeleteTransaction(TransactionId);
        }


        public Transaction UpdateTransaction(Transaction Transaction)
        {
            return _TransactionRepository.UpdateTransaction(Transaction);
        }
    }
}
