using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IUserRepository
    {

        List<ApplicationUser> ReadUsers(); // Returns a list of users

        void SaveUsers(List<ApplicationUser> users); // Takes a list of users (and saves to a data source)

        void UpdateUsers(List<ApplicationUser> users); // Takes a list of users and updates them in data source

        void UpdateUser(ApplicationUser user); // Updates a specific user

        void AddUser(ApplicationUser user); // Add a single user

        void DeleteUser(ApplicationUser user); // Remove a single user
    }
}
