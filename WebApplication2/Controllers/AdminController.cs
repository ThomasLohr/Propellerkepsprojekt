﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            return View();
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

            OrderViewModel orderViewModel = new OrderViewModel();

            orderViewModel.Order = _orderService.GetOrderById(Id);
            orderViewModel.OrderProduct = _orderProductService.GetOrderProductById(Id);

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            _orderService.Update(order);
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

        public IActionResult Users(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var foundUser = new List<ApplicationUser>();

                foundUser.Add(_userService.GetUserByName(searchString));

                return View(foundUser);
            }

            return View(_userService.GetAllusers());
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
