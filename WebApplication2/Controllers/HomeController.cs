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
using WebApplication2.Helpers;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Dummy lists of products for shopping cart
        private List<Product> products = new List<Product>();
        private List<Product> purchasedItems = new List<Product>();

        // Services
        private ProductService _productService;
        private OrderProductService _orderProductService;

        // Repositories from generic repository class
        private IGenericRepository<Order> _orderRepository = null;
        private IGenericRepository<Product> _productRepository = null;
        private IGenericRepository<OrderProduct> _orderProductRepository = null;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;

            // Repositories
            _orderRepository = new GenericRepository<Order>();
            _productRepository = new GenericRepository<Product>();
            _orderProductRepository = new GenericRepository<OrderProduct>();

            _userManager = userManager;

            // Services
            _productService = new ProductService();
            _orderProductService = new OrderProductService();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product(int id)
        {

            return View(_productRepository.GetById(id));
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
            ViewBag.CurrentUser = await _userManager.GetUserAsync(User);
            var orders = _orderRepository.GetAll();
            Cart shoppingcartz = SessionHelper.Get<Cart>(HttpContext.Session, "cart");
            List<Product> productList = new List<Product>();
            if (shoppingcartz != null)
            {
                foreach (var products in shoppingcartz.Products)
                {
                    productList.Add(_productRepository.GetById(products.ProductId));
                }
            }
            ViewBag.ShoppingCart = productList;
            if (shoppingcartz != null)
            {
                ViewBag.ShoppingQuantities = shoppingcartz.Products;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShoppingCartAsync(OrderViewModel cartOrder, List<int> shoppingCartIds, List<int> shoppingCartQuantities)
        {
            //Sends the order to the database
            _orderProductService.SendToDb(cartOrder, shoppingCartIds, shoppingCartQuantities, User.FindFirstValue(ClaimTypes.NameIdentifier));

            //Updates the stock of orderered products
            _productService.UpdateStock(shoppingCartIds, cartOrder);

            ViewBag.CurrentUser = await _userManager.GetUserAsync(User);
            //Clear the cart sessiondata/cookie
            HttpContext.Session.Clear();
            return View();
        }

        public IActionResult RemoveFromCart(int removalIndex)
        {
            Cart shoppingcartz = SessionHelper.Get<Cart>(HttpContext.Session, "cart");
            shoppingcartz.Products.RemoveAt(removalIndex);
            SessionHelper.Set<Cart>(HttpContext.Session, "cart", shoppingcartz);

            return RedirectToAction("ShoppingCart");
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult AddToCart(OrderProduct shoppingcartProduct)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            var shopCart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            if (shopCart == null)
            {
                shopCart = new Cart
                {
                    Products = new List<OrderProduct>()
                };
            }

            if (shopCart.Products.Exists(p => p.ProductId == shoppingcartProduct.ProductId))
            {
                shopCart.Products.First(p => p.ProductId == shoppingcartProduct.ProductId).Quantity += shoppingcartProduct.Quantity;
            }
            else
            {
                shopCart.Products.Add(new OrderProduct
                {
                    ProductId = shoppingcartProduct.ProductId,
                    Quantity = shoppingcartProduct.Quantity

                });
            }

            SessionHelper.Set<Cart>(HttpContext.Session, "cart", shopCart);

            return Redirect($"/Home/Product/{shoppingcartProduct.ProductId}");

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
                var resultCount = product.Count();

                ViewBag.searchResult = $"Visar {resultCount} resultat som matchar <b>{result}</b>.";

                return View(await product.ToListAsync());
            }

            ViewBag.searchResult = $"Inga resultat matchar <b>{result}</b>.";

            return View(new List<Product>());
        }
    }
}
