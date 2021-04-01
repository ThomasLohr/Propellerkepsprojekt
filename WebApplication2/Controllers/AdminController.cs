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
        List<ApplicationUser> UserList = new List<ApplicationUser>() { new ApplicationUser() { Email = "Johan.rova@protonmail.com", RegistrationDate = new DateTime(2021, 03, 25) } };
        private ProductService _productService;

        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            _productService = new ProductService();
        }

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult Products()
        {
            return View(_productService.GetAll());
        }

        public IActionResult Orders()
        {
            return View(OrderList);
        }

        [HttpGet]
        public IActionResult EditProduct()
        {
            return View();
        }


        public IActionResult RemoveProduct(int Id)
        {
            _productService.RemoveById(Id);
            return RedirectToAction("Products");
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _productService.Update(product);
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.Create(product);
            return View();
        }   

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        public IActionResult Users()
        {

            // DUMMY CODE FOR USER REPOSITORY AND SERVICE //

            //var userRepository = new UserRepository(_context);
            //var userService = new UserService(userRepository);

            //var allUsers = userService.GetAllusers(); // Gets all users from DB

            //var listOfUsers = new List<ApplicationUser> // Dummy list of users
            //{
            //       new ApplicationUser
            //       {
            //           FirstName = "Kalle",
            //           LastName = "Kula",
            //           Email = "Kalle.Kula@mail.com",
            //           PasswordHash = "SuperSecret",
            //           PhoneNumber = "123456",
            //           Street = "Stadsgatan 123",
            //           Zip = "321 45",
            //           City = "Staden",
            //           RegistrationDate = new DateTime(2021, 03, 25)
            //       }
            //    };

            //userService.SaveUsers(listOfUsers);

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
