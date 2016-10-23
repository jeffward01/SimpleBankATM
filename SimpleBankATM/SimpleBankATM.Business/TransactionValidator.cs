using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System;

namespace SimpleBankATM.Business
{
    public class TransactionValidator : ITransactionValidator
    {
        private readonly IAccountRepository _accountRepository;

        private readonly ITransactionRepository _transactionRepository;

        private readonly decimal _transactionAmount;

        private readonly Account _accountInformation;

        private readonly Transaction _transactionInformation;

        private readonly TransactionType _transactionType;

        public TransactionValidator(Transaction transaction, TransactionType transactionType)
        {
            _accountRepository = new AccountRepository();
            _transactionRepository = new TransactionRepository();
            _transactionAmount = transaction.TransactionAmount;
            _transactionInformation = transaction;
            _accountInformation = _accountRepository.GetAccountById(transaction.AccountId);
            _transactionType = transactionType;
        }

        public TransactionStatus IsValidTransaction()
        {
            var transactionStatus = new TransactionStatus();

            if (_transactionType == TransactionType.Withdrawl)
            {
                transactionStatus = IsWirthdrawlMoreThan90Percent((int)_transactionAmount);
                if (!transactionStatus.IsValid)
                {
                    return transactionStatus;
                }
                transactionStatus = WillAccountBeLessThan100((int)_transactionAmount);
                if (!transactionStatus.IsValid)
                {
                    return transactionStatus;
                }
            }
            else if (_transactionType == TransactionType.Deposit)
            {
                transactionStatus = IsDepositMoreThanTenThousand((int)_transactionAmount);
                if (!transactionStatus.IsValid)
                {
                    return transactionStatus;
                }
            }

            //SaveTransaction
            var result = SaveTransaction();
            if (!result)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "Error saving Transaction";
                return transactionStatus;
            }
            return transactionStatus;
        }

        public TransactionStatus IsValidUpdateTransaction()
        {
            var transactionStatus = new TransactionStatus();

            if (_transactionType == TransactionType.Withdrawl)
            {
                transactionStatus = IsWirthdrawlMoreThan90Percent((int)_transactionAmount);
                if (!transactionStatus.IsValid)
                {
                    return transactionStatus;
                }
                transactionStatus = WillAccountBeLessThan100((int)_transactionAmount);
                if (!transactionStatus.IsValid)
                {
                    return transactionStatus;
                }
            }
            else if (_transactionType == TransactionType.Deposit)
            {
                transactionStatus = IsDepositMoreThanTenThousand((int)_transactionAmount);
                if (!transactionStatus.IsValid)
                {
                    return transactionStatus;
                }
            }

            //SaveTransaction
            var result = SaveUpdateTransaction();
            if (!result)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "Error updatting Transaction";
                return transactionStatus;
            }
            return transactionStatus;
        }

        private bool SaveUpdateTransaction()
        {
            var originalTransaction = _transactionRepository.GetTransactionById(_transactionInformation.TransactionId);

            if (_transactionType == TransactionType.Withdrawl)
            {
                _accountInformation.Balance += originalTransaction.TransactionAmount;
                _accountInformation.Balance -= _transactionAmount;
            }
            else if (_transactionType == TransactionType.Deposit)
            {
                _accountInformation.Balance -= originalTransaction.TransactionAmount;
                _accountInformation.Balance += _transactionAmount;
            }
         
            try
            {
                _accountRepository.UpdateAccount(_accountInformation);
                _transactionRepository.CreateTransaction(_transactionInformation);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool SaveTransaction()
        {
            if (_transactionType == TransactionType.Withdrawl)
            {
                _accountInformation.Balance -= _transactionAmount;
            }
            else if (_transactionType == TransactionType.Deposit)
            {
                _accountInformation.Balance += _transactionAmount;
            }
          
            try
            {
                _accountRepository.UpdateAccount(_accountInformation);
                _transactionRepository.CreateTransaction(_transactionInformation);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR SAVING TRANSACTION");
                Console.WriteLine(" TRANSACTION TYPE: " + _transactionInformation.TransactionTypeId);
                Console.WriteLine(e.ToString());

                return false;
            }
            return true;
        }

        private TransactionStatus WillAccountBeLessThan100(int transactionAmount)
        {
            var transactionStatus = new TransactionStatus();
            var afterTransaction = _accountInformation.Balance - transactionAmount;
            if (afterTransaction < 100)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "Account balence will fall below $100. Error.";
                return transactionStatus;
            }
            transactionStatus.IsValid = true;
            transactionStatus.WarningMessage = "Success";

            return transactionStatus;
        }

        private TransactionStatus IsWirthdrawlMoreThan90Percent(int transactionAmount)
        {
            var percent90OfBalence = Double.Parse(_accountInformation.Balance.ToString()) * .9;
            var transactionStatus = new TransactionStatus();

            if (transactionAmount > percent90OfBalence)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "User cannot withdraw more than 90% of account balance. Error";
                return transactionStatus;
            }
            transactionStatus.IsValid = true;
            transactionStatus.WarningMessage = "Success";

            return transactionStatus;
        }

        private TransactionStatus IsDepositMoreThanTenThousand(int transactionAmount)
        {
            var transactionStatus = new TransactionStatus();

            if (transactionAmount > 10000)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "User cannot deposit more than $10,000 at a time. Error";
                return transactionStatus;
            }
            transactionStatus.IsValid = true;
            transactionStatus.WarningMessage = "Success";

            return transactionStatus;
        }
    }
}

/* An account cannot have less than $100 at any time in an account.

A user cannot withdraw more than 90% of their total balance

from an account in a single transaction.

A user cannot deposit more than $10,000 in a single transaction.  */