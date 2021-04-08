using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

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

        public List<OrderViewModel> GetOrderProductByOrderId(int id)
        {

            var orderProductInfo = (from OrderProduct in _ctx.OrderProduct
                        where OrderProduct.OrderId == id
                        join Product in _ctx.Products on OrderProduct.ProductId equals Product.Id
                        select new OrderViewModel 
                        { 
                            OrderProduct = OrderProduct, 
                            ProductName = Product.ProductName, 
                            Price = Product.Price * OrderProduct.Quantity,
                        }).ToList();

            return orderProductInfo;
        }
    }
    }
