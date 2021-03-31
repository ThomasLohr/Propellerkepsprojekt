using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> ReadUsers()
        {
            // Placeholder User List for file or DB. Replace with DBContext.

            var loadedUserList = new List<User>()
            {
               new User
               {
                   Id = 1,
                   FirstName = "Kalle",
                   LastName = "Kula",
                   Email = "Kalle.Kula@mail.com",
                   Password = "SuperSecret",
                   Phone = "123456",
                   Street = "Stadsgatan 123",
                   Zip = "321 45",
                   City = "Staden",
                   RegisterDate = new DateTime(2021, 03, 25)
               },

               new User
               {
                   Id = 2,
                   FirstName = "Benny",
                   LastName = "Banan",
                   Email = "Benny.Banan@mail.com",
                   Password = "SuperSecret",
                   Phone = "123456",
                   Street = "Banangatan 123",
                   Zip = "321 45",
                   City = "Staden",
                   RegisterDate = new DateTime(2021, 02, 08)
               },

               new User
               {
                   Id = 3,
                   FirstName = "Sture",
                   LastName = "Strularsson",
                   Email = "Struliz@mail.com",
                   Password = "SuperSecret",
                   Phone = "123456",
                   Street = "Strulgatan 123",
                   Zip = "321 45",
                   City = "Staden",
                   RegisterDate = new DateTime(2021, 02, 08)
               }
            };

            return loadedUserList; // Return the list of users when method is called
        }

        public void SaveUsers(List<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
