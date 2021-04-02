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

        public ProductService()
        {
            _ctx = new ApplicationDbContext();
        }

        public List<Product> GetAll()
        {
            return _ctx.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _ctx.Products.FirstOrDefault(p => p.Id.Equals(id));
        }
        public void Create(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
        }

        public void Update(Product product)
        {
            _ctx.Products.Update(product);
            _ctx.SaveChanges();
        }

        public void RemoveById(int Id)
        {
            var productToRemove = _ctx.Products.FirstOrDefault(p => p.Id.Equals(Id));
            _ctx.Products.Remove(productToRemove);
            _ctx.SaveChanges();
        }

        public IQueryable<Product> SearchProducts(string keyWord)
        {
            // Get all products from DB and save them to an IQueryable
            var product = from m in _ctx.Products
                          select m;

            // Check if the IQueryable contains the search keyword in tables ProductName, Modekl, Size, Color, Gender
            if (!string.IsNullOrEmpty(keyWord))
            {
                if (product.Any(s => s.ProductName.Contains(keyWord)))
                {
                    product = product.Where(s => s.ProductName.Contains(keyWord));
                }
                else if (product.Any(s => s.Model.Contains(keyWord)))
                {
                    product = product.Where(s => s.Model.Contains(keyWord));
                }
                else if (product.Any(s => s.Size.Contains(keyWord)))
                {
                    product  = product.Where(s => s.Size.Contains(keyWord));
                }
                else if (product.Any(s => s.Color.Contains(keyWord)))
                {
                    product = product.Where(s => s.Color.Contains(keyWord));
                }
                else if (product.Any(s => s.Gender.Contains(keyWord)))
                {
                    product = product.Where(s => s.Gender.Contains(keyWord));
                }
                else
                {
                    product = null;
                }
            }

            return product;
        }
    }
}
