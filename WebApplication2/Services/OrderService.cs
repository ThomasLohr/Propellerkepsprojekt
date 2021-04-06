using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class OrderService
    {
        private ApplicationDbContext _ctx;

        public OrderService()
        {
            _ctx = new ApplicationDbContext();
        }

        public List<Order> GetAll()
        {
            return _ctx.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders.FirstOrDefault(o => o.Id.Equals(id));
        }
        public void Create(Order order)
        {
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
        }

        public void Update(Order order)
        {
            _ctx.Orders.Update(order);
            _ctx.SaveChanges();
        }

        public void RemoveById(int Id)
        {
            var orderToRemove = _ctx.Orders.FirstOrDefault(o => o.Id.Equals(Id));
            _ctx.Orders.Remove(orderToRemove);
            _ctx.SaveChanges();
        }
    }
}
