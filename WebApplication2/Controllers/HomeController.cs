using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.AspNetCore.Session;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private List<Product> products = new List<Product>();

        private List<Product> purchasedItems = new List<Product>();
        private ProductService _productService;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _productService = new ProductService();

            
            //Product product1 = new Product(1, "Propellerkeps hund", 45.50m,"En fantastisk Propellerkeps för din hund att njuta i och skyddar den från solens farliga strålar",  " ", "", 0);
            //product1.ImageUrl = "https://www.buttericks.se/media/catalog/product/cache/950aa184ad48b1712670346bf4c14135/2/5/252558_propellerkeps.jpg";
            //Product product2 = new Product(2, "Propellerkeps Creep", 40.50m, "Din Beskrivning", "", "", 0);
            //product2.ImageUrl = "https://www.netshirt.se/wp-content/uploads/2020/05/207513-Alt-Exempel-2.jpg";
            //Product product3 = new Product(3, "Propellerkeps Motor", 45.50m, "Din Beskrivning", "", "", 0);
            //product3.ImageUrl = "https://www.buttericks.se/media/catalog/product/p/r/propellerkeps_207513_snurr.gif";
            //Product product4 = new Product(4, "Propellerkeps Sverige", 45.50m, "Din Beskrivning", "", "", 0);
            //product4.ImageUrl = "https://assets.partyking.org/img/products/1300/propellerkeps-blagul-1.jpg";
            //Product product5 = new Product(5, "Propellerkeps Sunkig", 45.50m, "Din Beskrivning", "", "", 0);
            //product5.ImageUrl = "https://cdn.partykungen.se/img/products/1300/propellerkeps-2.jpg";
            //Product product6 = new Product(6, "Propellerkeps Sideswag", 45.50m, "Din Beskrivning", "", "", 0);
            //product6.ImageUrl = "https://www.buttericks.se/media/catalog/product/cache/acd4dfa8a93870011719dc120b266203/2/0/207513_propellerkeps_sida.jpg";

            //products.Add(product1);
            //products.Add(product2);
            //products.Add(product3);
            //products.Add(product4);
            //products.Add(product5);
            //products.Add(product6);
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
        
        public IActionResult ShoppingCart()
        {
            ViewBag.Purshases = purchasedItems;
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
    }
}
