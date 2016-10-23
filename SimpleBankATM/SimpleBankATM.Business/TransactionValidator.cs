using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System;

namespace SimpleBankATM.Business
{
    public class TransactionValidator
    {
        private readonly IAccountRepository _accountRepository;

        private readonly decimal _transactionAmount;

        private readonly int _accountId;

        private readonly Account _accountInformation;

        private readonly TransactionType _transactionType;

        public TransactionValidator(int amount, int accountId, TransactionType transactionType)
        {
            _accountRepository = new AccountRepository();
            _transactionAmount = amount;
            _accountId = accountId;
            _accountInformation = _accountRepository.GetAccountById(accountId);
            _transactionType = transactionType;

        }

        public TransactionStatus isValidTransaction()
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
            else
            {
                transactionStatus = WillAccountBeLessThan100((int)_transactionAmount);
                if (!transactionStatus.IsValid)
                {
                    return transactionStatus;
                }
            }
            return transactionStatus;
        }

        private TransactionStatus WillAccountBeLessThan100(int count)
        {
            var transactionStatus = new TransactionStatus();
            var afterTransaction = _accountInformation.Balance - count;
            if (afterTransaction < 100)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "Account balence will fall below $100. Error.";
            }
            transactionStatus.IsValid = true;
            return transactionStatus;
        }

        private TransactionStatus IsWirthdrawlMoreThan90Percent(int count)
        {
            var percent90OfBalence = Double.Parse(_accountInformation.Balance.ToString()) * .9;
            var transactionStatus = new TransactionStatus();

            if (count > percent90OfBalence)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "User cannot withdraw more than 90% of account balance. Error";
            }
            transactionStatus.IsValid = true;
            return transactionStatus;
        }

        private TransactionStatus IsDepositMoreThanTenThousand(int count)
        {
            var transactionStatus = new TransactionStatus();

            if (count > 10000)
            {
                transactionStatus.IsValid = false;
                transactionStatus.WarningMessage = "User cannot deposit more than $10,000 at a time. Error";
            }
            transactionStatus.IsValid = true;
            return transactionStatus;
        }
    }
}

/* An account cannot have less than $100 at any time in an account.

A user cannot withdraw more than 90% of their total balance

from an account in a single transaction.

A user cannot deposit more than $10,000 in a single transaction.  */