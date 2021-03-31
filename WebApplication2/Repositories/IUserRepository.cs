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
    }
}
