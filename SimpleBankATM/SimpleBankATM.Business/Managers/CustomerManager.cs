using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;
using System.Collections.Generic;

namespace SimpleBankATM.Business.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            return _customerRepository.CreateUser(customer);
        }

        public Customer GetCustomerByCustomerId(int customerId)
        {
            return _customerRepository.GetUserById(customerId);
        }

        public IList<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllUsers();
        }

        public bool DeleteCustomer(Customer customer)
        {
            return _customerRepository.DeleteUser(customer);
        }

        public bool DeleteCustomer(int customerID)
        {
            return _customerRepository.DeleteUser(customerID);
        }

        public Customer UodateCustomer(Customer customer)
        {
            return _customerRepository.UpdateUser(customer);
        }
    }
}