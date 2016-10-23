using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankATM.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _dataContext = new DataContext();

        //Get all users
        //Get user by id
        //Create new user
        //Edit user
        //Delete user

        public IList<User> GetAllUsers()
        {
            return _dataContext.Users.Where(_ => _.Deleted == null).ToList();
        }

        public User GetUserById(int userId)
        {
            return _dataContext.Users.FirstOrDefault(_ => _.UserId == userId);
        }

        public User CreateUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _dataContext.SetModified(user);
            _dataContext.SaveChanges();
            return user;
        }

        public bool DeleteUser(User user)
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
    }
}