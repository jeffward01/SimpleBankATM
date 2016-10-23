using SimpleBankATM.Business.Managers;
using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;

namespace SimpleBankATM.Console
{
    public class Application : IApplication
    {
        private readonly ICustomerRepository _userRepository;

        private readonly ITransactionManager _transactionManager;

        private readonly IAccountManager _accountManager;

        public Application(ICustomerRepository userRepository, ITransactionManager transactionManager, IAccountManager accountManager)
        {
            _userRepository = userRepository;
            _transactionManager = transactionManager;
            _accountManager = accountManager;
        }

        public void Run()
        {
            var newUser = new Customer();
            newUser.FirstName = "Joe";
            _userRepository.CreateUser(newUser);
            var createdUser = _userRepository.GetAllUsers();
            foreach (var user in createdUser)
            {
                System.Console.WriteLine(user.FirstName);
            }
            var newChanged = _userRepository.GetUserById(5);
            System.Console.WriteLine(newChanged.FirstName);
            newChanged.FirstName = "Wilbur";
            _userRepository.UpdateUser(newChanged);
            var verify = _userRepository.GetUserById(5);
            System.Console.WriteLine("Should say Wilbur:  " + verify.FirstName);

            //Add account to Wilbur
            _accountManager.AddAccount(5);
            var accounts = _accountManager.GetAllAccountsForCustomerId(5);
            var newAccount = accounts[0];
            System.Console.WriteLine("newAccount :  " + newAccount.AccountNumber + "   Routing: " + newAccount.RoutingNumber + "  Balanace: " + newAccount.Balance);

            //add transaction to new Account
            var reuslt = _transactionManager.AddTransaction(100, newAccount.AccountId, TransactionType.Deposit);
            System.Console.WriteLine("Transaction INformation :  IsValid:  " + reuslt.IsValid + "   Message: " + reuslt.WarningMessage);

            var updatedAccount = _accountManager.GetAccountByAccountId(newAccount.AccountId);
            System.Console.WriteLine("newAccount :  " + updatedAccount.AccountNumber + "   Routing: " + updatedAccount.RoutingNumber + "  Balanace: (should be $100 ----: " + updatedAccount.Balance);

            System.Console.ReadLine();
        }
    }
}