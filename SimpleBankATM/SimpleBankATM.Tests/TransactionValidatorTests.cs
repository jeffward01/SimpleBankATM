using FakeItEasy;
using NUnit.Framework;
using SimpleBankATM.Business;
using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;

namespace SimpleBankATM.Tests
{
    [TestFixture]
    public class TransactionValidatorTests
    {
        [Test]
        public void ShouldReturnFalse_DepositIsGreaterThanTenThousand()
        {
            var account = new Account();
            account.AccountId = 1;
            account.Balance = 100;
            account.CustomerId = 1;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 96;
            testData.AccountId = 2;
            testData.TransactionTypeId = 2;

            var testTransRepo = A.Fake<ITransactionRepository>();
            var testAccountRepo = A.Fake<IAccountRepository>();
            A.CallTo(() => testAccountRepo.GetAccountById(A<int>.Ignored)).Returns(account);
            var transactionValidoat = new TransactionValidator(testData, TransactionType.Withdrawl, testTransRepo, testAccountRepo);

            // Act
            var result = transactionValidoat.IsDepositMoreThanTenThousand(10001);

            // Assert
            Assert.AreEqual(result.IsValid, false, "Should be false");
        }

        [Test]
        public void ShouldReturnTrue_DepositIsTenThousand()
        {
            var account = new Account();
            account.AccountId = 1;
            account.Balance = 100;
            account.CustomerId = 1;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 96;
            testData.AccountId = 2;
            testData.TransactionTypeId = 2;

            var testTransRepo = A.Fake<ITransactionRepository>();
            var testAccountRepo = A.Fake<IAccountRepository>();
            A.CallTo(() => testAccountRepo.GetAccountById(A<int>.Ignored)).Returns(account);
            var transactionValidoat = new TransactionValidator(testData, TransactionType.Withdrawl, testTransRepo, testAccountRepo);

            // Act
            var result = transactionValidoat.IsDepositMoreThanTenThousand(10000);

            // Assert
            Assert.AreEqual(result.IsValid, true, "Should be true");
        }

        [Test]
        public void ShouldReturnTrue_DepositIsLessThanTenThousand()
        {
            var account = new Account();
            account.AccountId = 1;
            account.Balance = 100;
            account.CustomerId = 1;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 96;
            testData.AccountId = 2;
            testData.TransactionTypeId = 2;

            var testTransRepo = A.Fake<ITransactionRepository>();
            var testAccountRepo = A.Fake<IAccountRepository>();

            A.CallTo(() => testAccountRepo.GetAccountById(A<int>.Ignored)).Returns(account);
            var transactionValidoat = new TransactionValidator(testData, TransactionType.Withdrawl, testTransRepo, testAccountRepo);

            // Act
            var result = transactionValidoat.IsDepositMoreThanTenThousand(1000);

            // Assert
            Assert.AreEqual(result.IsValid, true, "Should be true");
        }

        [Test]
        public void ShouldReturnTrue_BalanceWillNotFallBelow100()
        {
            var account = new Account();
            account.AccountId = 1;
            account.Balance = 500;
            account.CustomerId = 1;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 96;
            testData.AccountId = 1;

            var testTransRepo = A.Fake<ITransactionRepository>();
            var testAccountRepo = A.Fake<IAccountRepository>();
            A.CallTo(() => testAccountRepo.GetAccountById(A<int>.Ignored)).Returns(account);

            var transactionValidoat = new TransactionValidator(testData, TransactionType.Withdrawl, testTransRepo, testAccountRepo);

            // Act
            var result = transactionValidoat.WillAccountBeLessThan100(1);

            // Assert
            Assert.AreEqual(result.IsValid, true, "Should be true");
        }

        [Test]
        public void ShouldReturnFalse_BalanceFallBelow100()
        {
            var account = new Account();
            account.AccountId = 1;
            account.Balance = 5;
            account.CustomerId = 1;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 96;
            testData.AccountId = 1;

            var testTransRepo = A.Fake<ITransactionRepository>();
            var testAccountRepo = A.Fake<IAccountRepository>();
            A.CallTo(() => testAccountRepo.GetAccountById(A<int>.Ignored)).Returns(account);
            var transactionValidoat = new TransactionValidator(testData, TransactionType.Withdrawl, testTransRepo, testAccountRepo);

            // Act
            var result = transactionValidoat.WillAccountBeLessThan100(5);

            // Assert
            Assert.AreEqual(result.IsValid, false, "Should be false");
        }

        [Test]
        public void ShouldReturnFalse_ISWithdrawGreaterThan90Percent()
        {
            var account = new Account();
            account.AccountId = 1;
            account.Balance = 100;
            account.CustomerId = 1;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 96;
            testData.AccountId = 2;
            testData.TransactionTypeId = 2;

            var testTransRepo = A.Fake<ITransactionRepository>();
            var testAccountRepo = A.Fake<IAccountRepository>();

            var transactionValidoat = new TransactionValidator(testData, TransactionType.Withdrawl, testTransRepo, testAccountRepo);

            A.CallTo(() => testAccountRepo.GetAccountById(A<int>.Ignored)).Returns(account);

            // Act
            var result = transactionValidoat.IsWirthdrawlMoreThan90Percent(95);

            // Assert
            Assert.AreEqual(result.IsValid, false, "Should be false");
        }
    }
}