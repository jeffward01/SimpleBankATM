using System.Collections.Generic;
using SimpleBankATM.Models;

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
    }
}