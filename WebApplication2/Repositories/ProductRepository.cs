using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _ctx;


        public ProductRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Product> ReadProducts()
        {
            return _ctx.Products.ToList();
        }

        public void SaveProducts(List<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
