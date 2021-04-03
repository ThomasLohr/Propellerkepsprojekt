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

        public void AddUser(ApplicationUser user)
        {
            _ctx.Add(user);
            _ctx.SaveChanges();
        }

        public void DeleteUser(ApplicationUser user)
        {
            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
            
        }

        public void SaveUsers(List<ApplicationUser> users)
        {

            foreach (var user in users)
            {
                _ctx.Users.Add(user);
            }

            _ctx.SaveChanges();

        }

        public void UpdateUser(ApplicationUser user)
        {
            var _user = _ctx.Users.FirstOrDefault(u => u.Id == user.Id);

            _user.UserName = user.UserName;
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Email = user.Email;
            _user.PhoneNumber = user.PhoneNumber;
            _user.Street = user.Street;
            _user.Zip = user.Zip;
            _user.City = user.City;


            _ctx.Update(_user);
            _ctx.SaveChanges();
        }

        public void UpdateUsers(List<ApplicationUser> users)
        {

            foreach (var user in users)
            {
                _ctx.Users.Update(user);
            }

            _ctx.SaveChanges();
        }
    }
}
