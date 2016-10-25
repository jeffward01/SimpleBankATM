using SimpleBankATM.Models;
using System.Collections.Generic;

namespace SimpleBankATM.Data.Repositories
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAllUsers();

        Customer GetUserById(int userId);

        Customer CreateUser(Customer user);

        Customer UpdateUser(Customer user);

        bool DeleteUser(Customer user);

        bool DeleteUser(int userId);

        int GetNumberOfAccounts(int customerId);

        int GetSumOfAccounts(int customerId);
        Customer GetCustomerByEmailAddress(string emailAddress);
    }
}