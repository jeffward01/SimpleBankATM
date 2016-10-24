using SimpleBankATM.Business.Managers;
using SimpleBankATM.Models;

namespace SimpleBankATM.Console
{
    public class UIManager
    {
        private readonly ICustomerManager _customerManager;
        private readonly IAccountManager _accountManager;

        private readonly ITransactionManager _transactionManager;

        public UIManager(ICustomerManager customerManager, IAccountManager accountManager, ITransactionManager transactionManager)
        {
            _customerManager = customerManager;
            _accountManager = accountManager;
            _transactionManager = transactionManager;
        }

        public void DisplayWelcome()
        {
            System.Console.WriteLine("Welcome to the best Small Bank Console Application");
            System.Console.WriteLine("Please press Enter to Continue....");
            System.Console.ReadLine();
            System.Console.Clear();
        }

        public void DisplayLogin()
        {
            System.Console.Clear();
            System.Console.WriteLine("If you have an account and would like to login please type 'login'.  Otherwise, create a new account and type 'create' ");
            var input = System.Console.ReadLine().ToLower();
            System.Console.WriteLine("You typed:  " + input);
            if (input != "create" && input != "login")
            {
                DisplayLogin();
            }

            if (input == "create")
            {
                CreateAccount();
            }
            else if (input == "login")
            {
                LoginToBank();
            }
        }

        public void CreateAccount()
        {
            System.Console.Clear();
            System.Console.WriteLine("Create a new Account");
            System.Console.WriteLine("Please enter FirstName");
            var firstName = System.Console.ReadLine();
            System.Console.WriteLine("Please enter LastName");
            var lastName = System.Console.ReadLine();

            System.Console.WriteLine("Please enter Email Address");
            var emailAddress = System.Console.ReadLine();

            System.Console.WriteLine("Please enter Social Security Number");
            var socialSecurityNumber = System.Console.ReadLine();

            System.Console.WriteLine("Please enter Date Of Birth  (MM/DD/YYYY)");
            var dateOfBirth = System.Console.ReadLine();

            var password = GetPassword();

            var newCustomer = new Customer();
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            newCustomer.EmailAddress = emailAddress;
            newCustomer.SocialSecurityNumber = socialSecurityNumber;
            newCustomer.DateOfBirth = dateOfBirth;
            newCustomer.Password = password;
            var result = CorrectNewCustomerInformation(newCustomer);

            if (result)
            {
                //Save and go to account screen
                SaveNewAccount(newCustomer);
            }
            else
            {
                CreateAccount();
            }
        }

        private bool CorrectNewCustomerInformation(Customer customer)
        {
            System.Console.Clear();
            System.Console.WriteLine("Is this correct?  (y/n)");
            System.Console.WriteLine("FirstName: " + customer.FirstName);
            System.Console.WriteLine("LastName: " + customer.LastName);

            System.Console.WriteLine("Email Address: " + customer.EmailAddress);

            System.Console.WriteLine("Social Security Number: " + customer.SocialSecurityNumber);

            System.Console.WriteLine("Date of Birth (MM/DD/YYYY): " + customer.DateOfBirth);

            var result = System.Console.ReadLine().ToLower();
            if (result != "y" && result != "n")
            {
                CorrectNewCustomerInformation(customer);
            }
            else if (result == "n")
            {
                return false;
            }

            return true;
        }

        private string GetPassword()
        {
            System.Console.WriteLine("Please enter Password");
            var firstPassword = System.Console.ReadLine();

            System.Console.WriteLine("Please enter Confirm Password");
            var secondPassword = System.Console.ReadLine();
            while (firstPassword != secondPassword)
            {
                System.Console.Clear();

                System.Console.WriteLine("Error, passwords are not equal, please enter matching passwords");
                GetPassword();
            }
            return firstPassword;
        }

        public void SaveNewAccount(Customer customer)
        {
            System.Console.Clear();

            _customerManager.AddCustomer(customer);
            System.Console.WriteLine("New Customer has been saved!  Please login!  press enter to continue");
            System.Console.ReadLine();
            System.Console.Clear();

            LoginToBank();
        }

        public void LoginToBank()
        {
            System.Console.WriteLine("This is the login Screen");
        }
    }
}