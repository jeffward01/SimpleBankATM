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
        public void ShouldReturnFalse_DepositGreaterThanTenThousand()
        {
            var newCustomer = new Customer();
            newCustomer.FirstName = "John";
            newCustomer.LastName = "Doe";

            var account = new Account();
            account.AccountId = 2;
            account.Balance = 5000;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 10001;
            testData.AccountId = 2;
            testData.TransactionTypeId = 1;

            var testTransRepo = A.Fake<ITransactionRepository>();
            testTransRepo.CreateTransaction(testData);

            var transactionValidoat = new TransactionValidator(testData, TransactionType.Deposit);

            // Act
            var result = transactionValidoat.IsDepositMoreThanTenThousand(10001);

            // Assert
            Assert.AreEqual(result.IsValid, false, "Should be false");
        }

        [Test]
        public void ShouldReturnFalse_BalanceFallBelow100()
        {
            var newCustomer = new Customer();
            newCustomer.FirstName = "John";
            newCustomer.LastName = "Doe";

            var account = new Account();
            account.AccountId = 2;
            account.Balance = 100;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 5;
            testData.AccountId = 2;
            testData.TransactionTypeId = 2;

            var testTransRepo = A.Fake<ITransactionRepository>();
            testTransRepo.CreateTransaction(testData);

            var transactionValidoat = new TransactionValidator(testData, TransactionType.Deposit);

            // Act
            var result = transactionValidoat.WillAccountBeLessThan100(5);

            // Assert
            Assert.AreEqual(result.IsValid, false, "Should be false");
        }

        [Test]
        public void ShouldReturnFalse_ISWithdrawGreaterThan90Percent()
        {
            var newCustomer = new Customer();
            newCustomer.FirstName = "John";
            newCustomer.LastName = "Doe";

            var account = new Account();
            account.AccountId = 2;
            account.Balance = 100;

            // Create test data
            var testData = new Transaction();
            testData.TransactionAmount = 96;
            testData.AccountId = 2;
            testData.TransactionTypeId = 2;

            var testTransRepo = A.Fake<ITransactionRepository>();
            testTransRepo.CreateTransaction(testData);

            var transactionValidoat = new TransactionValidator(testData, TransactionType.Deposit);

            // Act
            var result = transactionValidoat.IsWirthdrawlMoreThan90Percent(95);

            // Assert
            Assert.AreEqual(result.IsValid, false, "Should be false");
        }
    }
}