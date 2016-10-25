using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleBankATM.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        //Get all users
        //Get user by id
        //Create new user
        //Edit user
        //Delete user
        private readonly DbContext _dataContext;
        public CustomerRepository(IDbContextFactory factory)
        {
            _dataContext = factory.GetContext();
        }


        public IList<Customer> GetAllUsers()
        {
            using (var context = new DataContext())
            {
                return context.Customers.Where(_ => _.Deleted == null).ToList();
            }
        }

        public Customer GetCustomerByEmailAddress(string emailAddress)
        {
            using (var context = new DataContext())
            {
                return context.Customers.FirstOrDefault(_ => _.EmailAddress == emailAddress);
            }
        }

        public Customer GetUserById(int userId)
        {
            using (var context = new DataContext())
            {
                return context.Customers.FirstOrDefault(_ => _.CustomerId == userId);
            }
        }

        public Customer CreateUser(Customer user)
        {
            using (var context = new DataContext())
            {
                user.CreatedDate = DateTime.Now;
                context.Customers.Add(user);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return user;
            }
        }

        public int GetNumberOfAccounts(int customerId)
        {
            using (var contecxt = new DataContext())
            {
                return contecxt.Accounts.Count(_ => _.CustomerId == customerId && _.Deleted == null);
            }
        }

        public int GetSumOfAccounts(int customerId)
        {
            using (var contecxt = new DataContext())
            {

                var accounts= contecxt.Accounts.Where(_ => _.CustomerId == customerId && _.Deleted == null).ToList();
                return accounts.Sum(_ => _.Balance);
            }
        }


        public Customer UpdateUser(Customer user)
        {
            using (var context = new DataContext())
            {
                context.SetModified(user);
                context.SaveChanges();
                return context.Customers.FirstOrDefault(_ => _.CustomerId == user.CustomerId);
            }
      
        }

        public bool DeleteUser(Customer user)
        {
            using (var context = new DataContext())
            {
                user.Deleted = DateTime.Now;
                context.SetModified(user);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var context = new DataContext())
            {
                var user = context.Customers.FirstOrDefault(_ => _.CustomerId == userId);
                if (user == null)
                {
                    return false;
                }
                try
                {
                    user.Deleted = DateTime.Now;
                    context.SetModified(user);

                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}