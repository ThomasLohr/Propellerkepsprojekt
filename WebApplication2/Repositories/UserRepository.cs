using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _ctx = null;

        public UserRepository()
        {
            _ctx = new ApplicationDbContext();
        }

        public List<ApplicationUser> ReadUsers()
        {

            return _ctx.Users.ToList();

        }

        public void SaveUsers(List<ApplicationUser> users)
        {

            foreach (var user in users)
            {
                _ctx.Users.Add(user);
            }

            _ctx.SaveChanges();

        }
    }
}
