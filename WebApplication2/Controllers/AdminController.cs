using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Services;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        private ProductService _productService;
        private UserService _userService;
        private OrderService _orderService;
        private OrderProductService _orderProductService;
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            _productService = new ProductService();
            _userService = new UserService();
            _orderService = new OrderService();
            _orderProductService = new OrderProductService();
        }

        public IActionResult Index()
        {
            var viewModel = new AdminViewModel();

            viewModel.Orders = _orderService.GetAll();
            viewModel.OrderProducts = _orderProductService.GetAll();
            viewModel.Products = _productService.GetAll();

            viewModel.NumberOfOrders = viewModel.Orders.Count();
            viewModel.NumberOfOrdersSent = viewModel.Orders.Count(o => o.OrderSent);
            viewModel.NumberOfProducts = viewModel.Products.Count();
            viewModel.ProductTotalStock = viewModel.Products.Sum(p => p.Stock);

            return View(viewModel);
        }

        // PRODUCTS

        public IActionResult Products()
        {
            return View(_productService.GetAll());
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

        // ORDERS

        public IActionResult Orders()
        {

            return View(_orderService.GetAll());
        }

        [HttpGet]
        public IActionResult EditOrder(int Id)
        {

            var orderViewModel = new OrderViewModel();

            orderViewModel.Order = _orderService.GetOrderById(Id);
            orderViewModel.OrderProductsList = _orderProductService.GetOrderProductByOrderId(Id);
            orderViewModel.TotalPrice = orderViewModel.OrderProductsList.Sum(op => op.Price);

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrder(int id, OrderViewModel orderViewModel)
        {
            orderViewModel.Order.Id = id;

            //if (ModelState.IsValid)
            //{
            //    Order orderFromView = _context.Orders
            //                            .Where(o => o.Id == model.Order.Id)
            //                            .SingleOrDefault();

            //    orderFromView.Id = model.Order.Id;
            //    orderFromView.UserId = model.Order.UserId;
            //    orderFromView.ShippedDate = model.Order.ShippedDate;
            //    orderFromView.OrderSent = model.Order.OrderSent;

            //    _context.Entry(orderFromView).State = EntityState.Modified;
            //    _context.SaveChanges();

            //    //Include("person")

            //return RedirectToAction("Orders");
            //}
            //return View(model);

            _orderService.Update(orderViewModel.Order);
            return RedirectToAction("Orders");
        }
        public IActionResult RemoveOrder(int Id)
        {
            _orderService.RemoveById(Id);
            return RedirectToAction("Orders");
        }
        public IActionResult CreateOrder(Order order)
        {
            _orderService.Create(order);
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        // USERS

        public IActionResult Users(string searchId)
        {
            var foundUser = new List<ApplicationUser>();

            if (!string.IsNullOrEmpty(searchId))
            {
                foundUser.Add(_userService.GetUserById(searchId));

                if (foundUser.Any())
                return View(foundUser);
            }

            foundUser = _userService.GetAll();

            return View(foundUser);
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
