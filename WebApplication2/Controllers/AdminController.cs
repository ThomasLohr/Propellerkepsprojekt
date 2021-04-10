using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AdminController> _logger;

        // Services
        private ProductService _productService;
        private OrderService _orderService;
        private OrderProductService _orderProductService;
        private UserService _userService;

        // Repositories from generic repository class
        private IGenericRepository<Order> _orderRepository = null;
        private IGenericRepository<Product> _productRepository = null;
        private IGenericRepository<OrderProduct> _orderProductRepository = null;
        private IGenericRepository<ApplicationUser> _userRepository = null;

        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ILogger<AdminController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;

            // Repositories
            _orderRepository = new GenericRepository<Order>();
            _productRepository = new GenericRepository<Product>();
            _orderProductRepository = new GenericRepository<OrderProduct>();

            _userManager = userManager;

            // Services
            _productService = new ProductService();
            _orderService = new OrderService();
            _orderProductService = new OrderProductService();
            _userService = new UserService();
    }

        public IActionResult Index()
        {
            var viewModel = new AdminViewModel();

            viewModel.Orders = _orderRepository.GetAll();
            viewModel.OrderProducts = _orderProductRepository.GetAll();
            viewModel.Products = _productRepository.GetAll();

            viewModel.NumberOfOrders = viewModel.Orders.Count();
            viewModel.NumberOfOrdersSent = viewModel.Orders.Count(o => o.OrderSent);
            viewModel.NumberOfProducts = viewModel.Products.Count();
            viewModel.ProductTotalStock = viewModel.Products.Sum(p => p.Stock);

            return View(viewModel);
        }

        // PRODUCTS

        public IActionResult Products()
        {
            return View(_productRepository.GetAll());
        }

        [HttpGet]
        public IActionResult EditProduct(int Id)
        {
            
            return View(_productRepository.GetById(Id));
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _productRepository.Update(product);
            return RedirectToAction("Products");
        }


        public IActionResult RemoveProduct(int Id)
        {
            _productRepository.Delete(Id);
            return RedirectToAction("Products");
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productRepository.Insert(product);
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

            return View(_orderRepository.GetAll());
        }

        [HttpGet]
        public IActionResult EditOrder(int Id)
        {

            var orderViewModel = new OrderViewModel();

            orderViewModel.Order = _orderRepository.GetById(Id);
            orderViewModel.OrderProductsList = _orderProductService.GetOrderProductByOrderId(Id);
            orderViewModel.TotalPrice = orderViewModel.OrderProductsList.Sum(op => op.Price);

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrder(int id, OrderViewModel orderViewModel)
        {
            orderViewModel.Order.Id = id;

            _orderRepository.Update(orderViewModel.Order);
            return RedirectToAction("Orders");
        }
        public IActionResult RemoveOrder(int Id)
        {
            _orderRepository.Delete(Id);
            return RedirectToAction("Orders");
        }
        public IActionResult CreateOrder(Order order)
        {
            _orderRepository.Insert(order);
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
