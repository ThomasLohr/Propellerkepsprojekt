using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

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
