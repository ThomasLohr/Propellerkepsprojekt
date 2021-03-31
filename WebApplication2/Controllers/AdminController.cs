using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
       
        List<Order> OrderList = new List<Order>
        {
            new Order(){  CustomerId =12345, OrderQty = 2, RegistrationDate = new DateTime(2021, 03, 25), OrderSent = true}
        };
        List<User> UserList = new List<User>() { new User() { Email = "Johan.rova@protonmail.com", Password = "Johan#123", RegisterDate = new DateTime(2021, 03, 25) } };

        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Orders()
        {
            return View(OrderList);
        }

        public IActionResult Users(ApplicationDbContext context)
        {

            // DUMMY CODE FOR USER REPOSITORY AND SERVICE //

            var userRepository = new UserRepository(context);
            var userService = new UserService(userRepository);

            var allUsers = userService.GetAllusers(); // Gets all users from DB

            var listOfUsers = new List<User> // Dummy list of users
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

                userService.SaveUsers(listOfUsers);

            ////////////////////////////////////////////////

            return View(UserList);
        }
        public IActionResult EditOrder()
        {
            return View();
        }
        public IActionResult EditUser()
        {
            return View();
        }
    }
}
