using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
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

        public IList<Customer> GetAllUsers()
        {
            using (var context = new DataContext())
            {
                return context.Users.Where(_ => _.Deleted == null).ToList();
            }
        }

        public Customer GetUserById(int userId)
        {
            using (var context = new DataContext())
            {
                return context.Users.FirstOrDefault(_ => _.UserId == userId);
            }
        }

        public Customer CreateUser(Customer user)
        {
            using (var context = new DataContext())
            {
                user.CreatedDate = DateTime.Now;
                context.Users.Add(user);
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

        public Customer UpdateUser(Customer user)
        {
            using (var context = new DataContext())
            {
                context.SetModified(user);
                context.SaveChanges();
                return context.Users.FirstOrDefault(_ => _.UserId == user.UserId);
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
                var user = context.Users.FirstOrDefault(_ => _.UserId == userId);
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