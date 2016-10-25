using FakeItEasy;
using NUnit.Framework;
using SimpleBankATM.Business;
using SimpleBankATM.Business.Managers;
using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankATM.Tests
{
    [TestFixture]
    public class AccountManagerTests
    {
        [Test]
        public void GetsAllAccounts_ReturnsExpected()
        {
            var testData = new List<Account>
            {
                new Account {CustomerId = 1, Balance = 44, AccountTypeId = 1},
             new Account {CustomerId = 1, Balance = 500, AccountTypeId = 1},
            new Account {CustomerId = 1, Balance = 300, AccountTypeId = 2},
            };

            var context = A.Fake<IAccountRepository>();
            A.CallTo(() => context.GetAllAccounts()).Returns(testData);

            var productService = new AccountManager(context);

            // Act
            var accounts = productService.GetAllAccounts().ToList();

            // Assert
            Assert.AreEqual(3, accounts.Count(), "Should have 4");
            Assert.AreEqual(44, accounts.First().Balance, "Should be 44");
        }

        //Test user create account
        [Test]
        public void CreateAccount_UserCreateAccount()
        {
            var testData = new List<Account>
            {
                new Account {CustomerId = 1, Balance = 44, AccountTypeId = 1},
             new Account {CustomerId = 1, Balance = 500, AccountTypeId = 1},
            new Account {CustomerId = 1, Balance = 300, AccountTypeId = 2},
            };

            var context = A.Fake<IAccountRepository>();
            A.CallTo(() => context.GetAllAccounts()).Returns(testData);

            A.CallTo(() => context.CreateAccount(new Account { CustomerId = 1, Balance = 300, AccountTypeId = 2 })).Returns(new Account { CustomerId = 1, Balance = 300, AccountTypeId = 2 });

            var accountManager = new AccountManager(context);
            A.CallTo(() => context.GetAllAccounts()).Returns(testData);

            // Act
            var accounts = accountManager.AddAccount(1, AccountType.Checking);
            var count = accountManager.GetAllAccounts();

            // Assert
            Assert.IsInstanceOf<Account>(accounts);
        }

        [Test]
        public void DeleteAccount_UserDeleteAccount()
        {
            var context = A.Fake<IAccountRepository>();
            A.CallTo(() => context.GetAccountById(1)).Returns(new Account { CustomerId = 1, AccountId = 1, Balance = 300, AccountTypeId = 2 });

            A.CallTo(() => context.DeleteAccount(A<Account>.Ignored)).Returns(true);

            var accountManager = new AccountManager(context);

            // Act
            var result = accountManager.DeleteAccount(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UserCanWithdraw_UserCanWithdraw()
        {
            var context = A.Fake<ITransactionRepository>();
            var handler = A.Fake<ITransactionHandler>();
            var context1 = A.Fake<IAccountRepository>();

            var transaction = new Transaction();
            transaction.TransactionAmount = 15;
            transaction.AccountId = 1;

            TransactionStatus expenect = new TransactionStatus();
            expenect.IsValid = true;

            var transactionManager = new TransactionManager(context, handler);

            A.CallTo(() => context1.GetAccountById(A<int>.Ignored)).Returns(new Account { CustomerId = 1, AccountId = 1, Balance = 3000, AccountTypeId = 2 });

            A.CallTo(() => handler.IsValidTransaction(transaction, TransactionType.Withdrawl)).Returns(expenect);

            // Act
            var result = transactionManager.AddTransaction(15, 1, TransactionType.Withdrawl);

            // Assert
            Assert.False(result.IsValid);
        }

        [Test]
        public void UserCanWithdraw_UserCanDeposit()
        {
            var context = A.Fake<ITransactionRepository>();
            var handler = A.Fake<ITransactionHandler>();
            var context1 = A.Fake<IAccountRepository>();

            var transaction = new Transaction();
            transaction.TransactionAmount = 15;
            transaction.AccountId = 1;

            TransactionStatus expenect = new TransactionStatus();
            expenect.IsValid = true;

            var transactionManager = new TransactionManager(context, handler);

            A.CallTo(() => context1.GetAccountById(A<int>.Ignored)).Returns(new Account { CustomerId = 1, AccountId = 1, Balance = 3000, AccountTypeId = 2 });

            A.CallTo(() => handler.IsValidTransaction(transaction, TransactionType.Deposit)).Returns(expenect);

            // Act
            var result = transactionManager.AddTransaction(15, 1, TransactionType.Deposit);

            // Assert
            Assert.False(result.IsValid);
        }

        [Test]
        public void GeneratesRandom10DigitNumber()
        {
            var fakeManager = A.Fake<AccountManager>();

            // Act
            var randomNumber = fakeManager.GenerateNumber();

            // Assert
            Assert.AreEqual(10, randomNumber.Count(), "Should be 10 digits long");
            Assert.AreNotEqual(11, randomNumber.Count(), "Random number is 10 digits, not 11");
            Assert.IsInstanceOf<string>(randomNumber, "Should be a string");
        }
    }
}