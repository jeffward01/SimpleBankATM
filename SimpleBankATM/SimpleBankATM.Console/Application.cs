using System;
using System.Linq;
using SimpleBankATM.Business.Managers;
using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;

namespace SimpleBankATM.Console
{
    public class Application : IApplication
    {
        private readonly ICustomerManager _customerManager;

        private readonly ITransactionManager _transactionManager;

        private readonly IAccountManager _accountManager;

        public Application(ICustomerManager customerManager, ITransactionManager transactionManager, IAccountManager accountManager)
        {
            _customerManager = customerManager;
            _transactionManager = transactionManager;
            _accountManager = accountManager;
        }

        public void Run()
        {
          var uiManager = new UIManager(_customerManager);
            uiManager.DisplayWelcome();

            //login
            uiManager.DisplayLogin();
        }
    }
}





/* Test Info
 *   var newUser = new Customer();
            newUser.FirstName = "Joe";
           // _userRepository.CreateUser(newUser);
            var createdUser = _userRepository.GetAllUsers();
            foreach (var user in createdUser)
            {
                System.Console.WriteLine(user.FirstName);
            }
            var newChanged = _userRepository.GetUserById(1);
            System.Console.WriteLine(newChanged.FirstName);
            newChanged.FirstName = "Wilbur";
            _userRepository.UpdateUser(newChanged);
            var verify = _userRepository.GetUserById(1);
            System.Console.WriteLine("Should say Wilbur:  " + verify.FirstName);

          //Add account to Wilbur
          //
     //       _accountManager.AddAccount(1, AccountType.Checking);
            var accounts = _accountManager.GetAllAccountsForCustomerId(1);
            var newAccount = accounts.FirstOrDefault(_ => _.AccountId == 1);
            System.Console.WriteLine("newAccount :  " + newAccount.AccountNumber + "   Routing: " + newAccount.RoutingNumber + " Original  Balanace: " + newAccount.Balance);

            //add transaction to new Account
            var newTotal = newAccount.Balance + 100;
            System.Console.WriteLine("Adding Deposit of 100. new Balence should be: " + newTotal);
            var reuslt = _transactionManager.AddTransaction(100, newAccount.AccountId, TransactionType.Deposit);
            System.Console.WriteLine("Transaction INformation :  IsValid:  " + reuslt.IsValid + "   Message: " + reuslt.WarningMessage);

            var updatedAccount = _accountManager.GetAccountByAccountId(1);
            System.Console.WriteLine("newAccount :  " + updatedAccount.AccountNumber + "   Routing: " + updatedAccount.RoutingNumber + "  Balanace: should match above " + updatedAccount.Balance);

            ////add transaction withdrwal
            var newBalence = updatedAccount.Balance - 5;
            System.Console.WriteLine("Account Balence is: " + updatedAccount.Balance + " Adding a Withdrawl of 5.  Balence should be:" + newBalence.ToString());
            var reusl1t = _transactionManager.AddTransaction(5, newAccount.AccountId, TransactionType.Withdrawl);
            System.Console.WriteLine("Transaction INformation :  IsValid:  " + reusl1t.IsValid + "   Message: " + reusl1t.WarningMessage);



            var updatedAccount1 = _accountManager.GetAccountByAccountId(newAccount.AccountId);
            System.Console.WriteLine("newAccount :  " + updatedAccount1.AccountNumber + "   Routing: " + updatedAccount1.RoutingNumber + "  Balanace: (Should match above " + updatedAccount1.Balance);

            System.Console.ReadLine(); */
