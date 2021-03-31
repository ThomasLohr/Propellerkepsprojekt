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

        public ApplicationUser GetByUserName(string Name)
        {
            var listOfUsers = _userRepository.ReadUsers(); // Call Readusers() from UserRepository
            return listOfUsers.FirstOrDefault(u => u.FirstName == Name);
        }

        public List<ApplicationUser> GetAllusers()
        {
            var listOfAllUsers = _userRepository.ReadUsers();
            return listOfAllUsers;
        }

        public void SaveUsers(List<ApplicationUser> users)
        {
            _userRepository.SaveUsers(users);
        }

    }
}
