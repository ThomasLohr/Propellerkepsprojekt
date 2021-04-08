using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private List<Product> products = new List<Product>();

        private List<Product> purchasedItems = new List<Product>();
        private ProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;
        private OrderService _orderService;



        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _productService = new ProductService();
            _userManager = userManager;
            _orderService = new OrderService();

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product(int id)
        {

            return View(_productService.GetProductById(id));
        }

        public IActionResult Products()
        {


            return View(_productService.GetAll()); ;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Colors()
        {
            return View();
        }
        
        public async Task<IActionResult> ShoppingCartAsync()
        {
            ViewBag.Purshases = purchasedItems;
            ViewBag.CurrentUser = await _userManager.GetUserAsync(User);
            List<Product> productList = new List<Product>();
            productList.Add(_productService.GetProductById(1));
            ViewBag.Products = productList;
            List<Order> orders = _orderService.GetAll();
            
            List<Product> products = ViewBag.Products;

            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public async Task<IActionResult> Search(string result)
        {
            var product = _productService.SearchProducts(result);

            if (product != null)
            {
                ViewBag.searchResult = $"Visar alla resultat som matchar <b>{result}</b>.";

                return View(await product.ToListAsync());
            }

            ViewBag.searchResult = $"Inga resultat matchar <b>{result}</b>.";

            return View(new List<Product>());
        }
    }
}
