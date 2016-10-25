using FakeItEasy;
using NUnit.Framework;
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