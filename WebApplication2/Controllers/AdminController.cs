using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            new Order(){ CustomerName ="Johan Rova", ItemAmount = 2, OrderTime = new DateTime(2021, 03, 25), OrderSent = true}
        };
        List<User> UserList = new List<User>() { new User() { Email = "Johan.rova@protonmail.com", Password = "Johan#123", RegisterDate = new DateTime(2021, 03, 25) } };

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Orders()
        {
            return View(OrderList);
        }
        public IActionResult Users()
        {

            // DUMMY CODE FOR USER REPOSITORY AND SERVICE //

            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            var allUsers = userService.GetAllusers();

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
