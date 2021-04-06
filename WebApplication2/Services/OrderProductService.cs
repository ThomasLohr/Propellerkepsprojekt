using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class OrderProductService
    {
        private ApplicationDbContext _ctx;
        public OrderProductService()
        {
            _ctx = new ApplicationDbContext();
        }

        public List<OrderProduct> GetAll()
        {
            return _ctx.OrderProduct.ToList();
        }

        public OrderProduct GetOrderProductById(int id)
        {
            return _ctx.OrderProduct.FirstOrDefault(o => o.Id.Equals(id));
        }
    }
}
