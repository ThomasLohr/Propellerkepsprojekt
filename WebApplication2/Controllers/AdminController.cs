using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private OrderProductService _orderProductService;

        // Repositories from generic repository class
        private IGenericRepository<Order> _orderRepository = null;
        private IGenericRepository<Product> _productRepository = null;
        private IGenericRepository<OrderProduct> _orderProductRepository = null;

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
            _orderProductService = new OrderProductService();
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

        public IActionResult Users(string searchId, string errorMessage)
        {
            ViewBag.Error = errorMessage;

            return View(_userManager.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Users(string searchId)
        {

            var foundUser = new List<ApplicationUser>();

            if (!string.IsNullOrEmpty(searchId))
            {
                searchId.Trim();

                if (_userManager.Users.Any(u => u.Id.Equals(searchId)))
                {
                    foundUser.Add(await _userManager.FindByIdAsync(searchId));
                    return View(foundUser);
                }
            }

            return RedirectToAction("Users");
        }

        public async Task<IActionResult> EditUser(string Id)
        {
            return View(await _userManager.FindByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string Id, ApplicationUser editUser)
        {

            var user = await _userManager.FindByIdAsync(Id);

            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.Email = editUser.Email;
            user.PhoneNumber = editUser.PhoneNumber;
            user.Street = editUser.Street;
            user.Zip = editUser.Zip;
            user.City = editUser.City;

            await _userManager.UpdateAsync(user);
         
            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(ApplicationUser user)
        {
            await _userManager.CreateAsync(user);
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        public async Task<IActionResult> RemoveUser(string Id)
        {
            var exmsg = "";

            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                await _userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                exmsg = ex.GetBaseException().Message;
            }

            return RedirectToAction("Users", new { errorMessage = exmsg });
        }
    }
}
