using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankATM.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataContext _dataContext = new DataContext();

        //Get all users
        //Get user by id
        //Create new user
        //Edit user
        //Delete user

        public IList<Customer> GetAllUsers()
        {
            return _dataContext.Users.Where(_ => _.Deleted == null).ToList();
        }

        public Customer GetUserById(int userId)
        {
            return _dataContext.Users.FirstOrDefault(_ => _.UserId == userId);
        }

        public Customer CreateUser(Customer user)
        {
            user.CreatedDate = DateTime.Now;
            _dataContext.Users.Add(user);
            try
            {
                _dataContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return user;
        }

        public Customer UpdateUser(Customer user)
        {
            _dataContext.SetModified(user);
            _dataContext.SaveChanges();
            return _dataContext.Users.FirstOrDefault(_ => _.UserId == user.UserId);
        }

        public bool DeleteUser(Customer user)
        {
            user.Deleted = DateTime.Now;
            _dataContext.SetModified(user);
            try
            {
                _dataContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var user = _dataContext.Users.FirstOrDefault(_ => _.UserId == userId);
            if (user == null)
            {
                return false;
            }
            try
            {
                user.Deleted = DateTime.Now;
            _dataContext.SetModified(user);
           
                _dataContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}