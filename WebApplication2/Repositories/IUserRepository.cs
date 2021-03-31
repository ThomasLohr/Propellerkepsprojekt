using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IUserRepository
    {

        List<User> ReadUsers(); // Returns a list of users
        void SaveUsers(List<User> users); // Takes a list of users (and saves to a data source)
    }
}
