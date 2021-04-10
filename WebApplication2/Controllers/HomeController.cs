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
using WebApplication2.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        private OrderProductService _orderProductService;






        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _productService = new ProductService();
            _userManager = userManager;
            _orderService = new OrderService();
            _orderProductService = new OrderProductService();

        }


        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString("Name");
            if (name != null)
            {
                var convertedProduct = JsonSerializer.Deserialize<List<Product>>(name);
                return View(convertedProduct);
            }
            return View(model: name);
        }

        public IActionResult SaveName()
        {
            List<Product> products = new List<Product>();
            products.Add(_productService.GetProductById(1));
            products.Add(_productService.GetProductById(2));
            products.Add(_productService.GetProductById(3));
            products.Add(_productService.GetProductById(4));

            HttpContext.Session.SetString("Name", JsonSerializer.Serialize(products));
            return RedirectToAction("Index");
        }


        public IActionResult Product(int id)
        {

            return View(_productService.GetProductById(id));
        }

        public IActionResult Products(string category)
        {

            return View(_productService.SortByCategory(category));
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Colors()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShoppingCartAsync()
        {
            ViewBag.Purshases = purchasedItems;
            ViewBag.CurrentUser = await _userManager.GetUserAsync(User);
            List<Product> productList = new List<Product>();
            productList.Add(_productService.GetProductById(1));
            productList.Add(_productService.GetProductById(2));
            ViewBag.Products = productList;
            List<Order> orders = _orderService.GetAll();

            List<Product> products = ViewBag.Products;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShoppingCartAsync(OrderViewModel cartOrder, List<int> shoppingCartIds, List<int> shoppingCartQuantities)
        {
            //_productService.Create(product);
            //cartOrder.OrderProduct = new OrderProduct() { Quantity = cartOrder.OrderProduct.Quantity };
            cartOrder.Order = new Order();
            //cartOrder.Order.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.Create(cartOrder.Order);
            cartOrder.OrderProduct = new OrderProduct();
            cartOrder.OrderProduct.OrderId = cartOrder.Order.Id;
            for (int i = 1; i <= shoppingCartIds.Count; i++)
            {
                cartOrder.OrderProduct.ProductId = shoppingCartIds[i - 1];
                cartOrder.OrderProduct.Quantity = shoppingCartQuantities[i - 1];
                _orderProductService.Create(cartOrder.OrderProduct);
                cartOrder.OrderProduct.Id = 0;
            }
            //cartOrder.OrderProduct.ProductId = shoppingCartIds[0];
            //_orderProductService.Create(cartOrder.OrderProduct);
            //For populating the view after order is made
            ViewBag.CurrentUser = await _userManager.GetUserAsync(User);
            List<Product> productList = new List<Product>();
            productList.Add(_productService.GetProductById(1));
            productList.Add(_productService.GetProductById(2));
            ViewBag.Products = productList;
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
