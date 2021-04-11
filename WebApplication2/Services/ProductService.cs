using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class ProductService
    {
        private ApplicationDbContext _ctx;
        private GenericRepository<Product> _productRepository;

        public ProductService()
        {
            _ctx = new ApplicationDbContext();
            _productRepository = new GenericRepository<Product>();
        }

        public IEnumerable<Product> SortByCategory(string category)
        {
            if (category == "Djur")
            {
                return _ctx.Products.Where(p => p.Category.Equals(category)).ToList();
            }
            else if (category == "Människa")
            {
                return _ctx.Products.Where(p => p.Category.Equals(category)).ToList();
            }
            else if (category == "Speciellatillfällen")
            {
                return _ctx.Products.Where(p => p.Category.Equals(category)).ToList();
            }
            return _productRepository.GetAll();
        }

        public IQueryable<Product> SearchProducts(string keyWord)
        {
            // Get all products from DB and save them to an IQueryable
            var products = _productRepository.GetAllRaw();

            //Check if the IQueryable contains the search keyword in tables ProductName, Model, Size, Color, Gender, Category
            if (!string.IsNullOrEmpty(keyWord))
            {
                if (products.Any(s => s.ProductName.Contains(keyWord)))
                {
                    products = products.Where(s => s.ProductName.Contains(keyWord));
                }
                else if (products.Any(s => s.Model.Contains(keyWord)))
                {
                    products = products.Where(s => s.Model.Contains(keyWord));
                }
                else if (products.Any(s => s.Size.Contains(keyWord)))
                {
                    products = products.Where(s => s.Size.Contains(keyWord));
                }
                else if (products.Any(s => s.Color.Contains(keyWord)))
                {
                    products = products.Where(s => s.Color.Contains(keyWord));
                }
                else if (products.Any(s => s.Gender.Contains(keyWord)))
                {
                    products = products.Where(s => s.Gender.Contains(keyWord));
                }
                else if (products.Any(s => s.Category.Contains(keyWord)))
                {
                    products = products.Where(s => s.Category.Contains(keyWord));
                }
                else
                {
                    products = null;
                }
            }

            return products;
        }
    }
}
