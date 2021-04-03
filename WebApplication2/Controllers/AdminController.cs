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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
       
        List<Order> OrderList = new List<Order>
        {
            new Order(){  CustomerId =12345, OrderQty = 2, RegistrationDate = new DateTime(2021, 03, 25), OrderSent = true}
        };
        
        private ProductService _productService;
        private UserService _userService;
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            _productService = new ProductService();
            _userService = new UserService();
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
        public IActionResult EditProduct(int Id)
        {
            
            return View(_productService.GetProductById(Id));
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Products");
        }


        public IActionResult RemoveProduct(int Id)
        {
            _productService.RemoveById(Id);
            return RedirectToAction("Products");
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
        public IActionResult Users(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                return View(_userService.GetByUserName(searchString));
            }

            return View(_userService.GetAllusers());
        }
        public IActionResult EditOrder()
        {
            return View();
        }
        public IActionResult EditUser(string Id)
        {
            return View(_userService.GetUserById(Id));
        }

        [HttpPost]
        public IActionResult EditUser(ApplicationUser user)
        {
            _userService.UpdateUser(user);

            return RedirectToAction("Users");
        }

        [HttpPost]
        public IActionResult CreateUser(ApplicationUser user)
        {
            _userService.Create(user);
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult RemoveUser(string Id)
        {
            _userService.RemoveById(Id);
            return RedirectToAction("Users");
        }
    }
}
