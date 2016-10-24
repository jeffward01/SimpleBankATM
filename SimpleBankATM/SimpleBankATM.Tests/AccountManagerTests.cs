using FakeItEasy;
using NUnit.Framework;
using SimpleBankATM.Business.Managers;
using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SimpleBankATM.Tests
{
    [TestFixture]
    public class AccountManagerTests
    {
        [Test]
        public void GetsAllAccounts_ReturnsExpected()
        {
            var newCustomer = new Customer();
            newCustomer.FirstName = "John";
            newCustomer.LastName = "Doe";

            // Create test data
            var testData = new List<Account>
            {
                new Account {CustomerId = 1, Balance = 44, AccountTypeId = 1},
             new Account {CustomerId = 1, Balance = 500, AccountTypeId = 1},
            new Account {CustomerId = 1, Balance = 300, AccountTypeId = 2},
            };

            // Arrange
            var set =
                A.Fake<DbSet<Account>>(
                        o => o.Implements(typeof(IQueryable<Account>)).Implements(typeof(IDbAsyncEnumerable<Account>)))
                    .AddRange(testData);

            var context = A.Fake<IAccountRepository>();
            A.CallTo(() => context.GetAllAccounts()).Returns(testData);

            var productService = new AccountManager(context);

            // Act
            var accounts = productService.GetAllAccounts().ToList();

            // Assert
            Assert.AreEqual(3, accounts.Count(), "Should have 4");
            Assert.AreEqual(44, accounts.First().Balance, "Should be 44");
        }
    }
}