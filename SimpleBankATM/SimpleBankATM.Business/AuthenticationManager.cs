using SimpleBankATM.Models;

namespace SimpleBankATM.Business
{
    public static class AuthenticationManager
    {
        public static Customer AuthenticatedCustomer { get; set; }
        public static bool IsAuth { get; set; }

        public static void Login(Customer customer)
        {
            AuthenticatedCustomer = customer;
            IsAuth = true;
        }

        public static void LogOut()
        {
            AuthenticatedCustomer = null;
            IsAuth = false;
        }

        public static bool IsAuthenticated(int customerId)
        {
            if (customerId != AuthenticatedCustomer.CustomerId)
            {
                LogOut();
                return false;
            }
            return true;
        }
    }
}