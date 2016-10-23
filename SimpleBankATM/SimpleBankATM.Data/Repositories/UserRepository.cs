using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;

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

    }
}
