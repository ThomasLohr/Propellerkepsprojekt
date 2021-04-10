using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class UserService
    {
        private GenericRepository<ApplicationUser>_userRepository = null;

        public UserService()
        {
            _userRepository = new GenericRepository<ApplicationUser>();
        }


        public void SetFirstName(ApplicationUser user, string firstName)
        {
            user.FirstName = firstName;
            _userRepository.Update(user);
        }

        public void SetLastName(ApplicationUser user, string lastName)
        {
            user.LastName = lastName;
            _userRepository.Update(user);
        }

        public void SetStreet(ApplicationUser user, string street)
        {
            user.Street = street;
            _userRepository.Update(user);
        }        
        public void SetZip(ApplicationUser user, string zip)
        {
            user.Zip = zip;
            _userRepository.Update(user);
        }        
        public void SetCity(ApplicationUser user, string city)
        {
            user.City = city;
            _userRepository.Update(user);
        }
    }
}
