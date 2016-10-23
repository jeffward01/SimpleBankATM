using System.Collections.Generic;
using SimpleBankATM.Models;

namespace SimpleBankATM.Business.Managers
{
    public interface ICustomerManager
    {
        Customer AddCustomer(Customer customer);
        Customer GetCustomerByCustomerId(int customerId);
        IList<Customer> GetAllCustomers();
        bool DeleteCustomer(Customer customer);
        bool DeleteCustomer(int customerID);
        Customer UodateCustomer(Customer customer);
    }
}