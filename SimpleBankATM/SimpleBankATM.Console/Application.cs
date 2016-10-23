using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NLog.Layouts;
using SimpleBankATM.Data.Repositories;
using SimpleBankATM.Models;

namespace SimpleBankATM.Console
{
    public class Application : IApplication
    {
        private readonly ICustomerRepository _userRepository;
        public Application(ICustomerRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Run()
        {
            var newUser = new Customer();
            newUser.FirstName = "Joe";
            _userRepository.CreateUser(newUser);
            var createdUser = _userRepository.GetAllUsers();
            foreach (var user in createdUser)
            {
                System.Console.WriteLine(user.FirstName);

            }
            var newChanged = _userRepository.GetUserById(5);
           System.Console.WriteLine(newChanged.FirstName);
            newChanged.FirstName = "Wilbur";
            _userRepository.UpdateUser(newChanged);
            var verify = _userRepository.GetUserById(5);
            System.Console.WriteLine("Should say Wilbur:  " + verify.FirstName );

            System.Console.ReadLine();
        }
    }
}
