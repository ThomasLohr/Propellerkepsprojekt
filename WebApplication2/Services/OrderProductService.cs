using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.ViewModels;

namespace WebApplication2.Services
{
    public class OrderProductService
    {
        private ApplicationDbContext _ctx = null;
        private IGenericRepository<Order> _orderRepository;
        private IGenericRepository<OrderProduct> _orderProductRepository;

        public OrderProductService()
        {
            _ctx = new ApplicationDbContext();
            _orderRepository = new GenericRepository<Order>();
            _orderProductRepository = new GenericRepository<OrderProduct>();
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


        public void SendToDb(OrderViewModel cartOrder, List<int> shoppingCartIds, List<int> shoppingCartQuantities, string userId)
        {
            
            cartOrder.Order = new Order();
            cartOrder.Order.UserId = userId;
            _orderRepository.Insert(cartOrder.Order);
            cartOrder.OrderProduct = new OrderProduct();
            cartOrder.OrderProduct.OrderId = cartOrder.Order.Id;
            for (int i = 1; i <= shoppingCartIds.Count; i++)
            {
                cartOrder.OrderProduct.ProductId = shoppingCartIds[i - 1];
                cartOrder.OrderProduct.Quantity = shoppingCartQuantities[i - 1];
                _orderProductRepository.Insert(cartOrder.OrderProduct);
                cartOrder.OrderProduct.Id = 0;
            }
        }
    }
}
