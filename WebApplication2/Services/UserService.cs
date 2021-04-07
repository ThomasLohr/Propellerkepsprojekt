using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{

    // All methods for getting User data from DB goes here

    public class UserService
    {
        private IUserRepository _userRepository = null;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public ApplicationUser GetUserByName(string Name)
        {

            var listOfAllUsers = _userRepository.ReadUsers();

            var userByName = listOfAllUsers.FirstOrDefault(u => u.FirstName.Contains(Name));

            return userByName;
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

        public ApplicationUser GetUserById(string id)
        {
            var userById = _userRepository.ReadUsers();
            
            var user = userById.FirstOrDefault(p => p.Id.Equals(id));

            return user;
        }

        public void UpdateUser(ApplicationUser user)
        {
            _userRepository.UpdateUser(user);
        }

        public void Create(ApplicationUser user)
        {
            _userRepository.AddUser(user);

        }

        public void RemoveById(string Id)
        {
            var user = _userRepository.ReadUsers().FirstOrDefault(p => p.Id.Equals(Id));

            _userRepository.DeleteUser(user);
        }


        public void SetFirstName(ApplicationUser user, string firstName)
        {
            user.FirstName = firstName;
            UpdateUser(user);
        }

        public void SetLastName(ApplicationUser user, string lastName)
        {
            user.LastName = lastName;
            UpdateUser(user);
        }
    }
}
