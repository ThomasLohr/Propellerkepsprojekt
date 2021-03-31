using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{

    // All methods for getting User data from DB goes here

    public class UserService
    {
        private IUserRepository _userRepository = null;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetByUserName(string Name)
        {
            var listOfUsers = _userRepository.ReadUsers(); // Call Readusers() from UserRepository
            return listOfUsers.FirstOrDefault(u => u.FirstName == Name);
        }

        public List<User> GetAllusers()
        {
            var listOfAllUsers = _userRepository.ReadUsers();
            return listOfAllUsers;
        }
    }
}
