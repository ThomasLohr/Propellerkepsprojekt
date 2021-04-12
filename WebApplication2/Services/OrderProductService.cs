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
using WebApplication2.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace WebApplication2.Services
{
    public class OrderProductService
    {
        private ApplicationDbContext _ctx = null;
        private IGenericRepository<Order> _orderRepository;
        private IGenericRepository<OrderProduct> _orderProductRepository;
        private IGenericRepository<Product> _productRepository;

        public OrderProductService()
        {
            _ctx = new ApplicationDbContext();
            _orderRepository = new GenericRepository<Order>();
            _orderProductRepository = new GenericRepository<OrderProduct>();
            _productRepository = new GenericRepository<Product>();
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


        public void RemoveFromCart(int removalIndex, HttpContext httpCtx)
        {
            Cart shoppingcartz = SessionHelper.Get<Cart>(httpCtx.Session, "cart");
            shoppingcartz.Products.RemoveAt(removalIndex);
            SessionHelper.Set<Cart>(httpCtx.Session, "cart", shoppingcartz);
        }


        public void AddToCart(OrderProduct shoppingcartProduct, HttpContext httpCtx)
        {
            var shopCart = SessionHelper.Get<Cart>(httpCtx.Session, "cart");

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

            SessionHelper.Set<Cart>(httpCtx.Session, "cart", shopCart);
        }

        public void UpdateCart(List<int> shoppingCartQuantities, HttpContext httpCtx)
        {
            var shopCart = SessionHelper.Get<Cart>(httpCtx.Session, "cart");

            if (shopCart == null)
            {
                shopCart = new Cart
                {
                    Products = new List<OrderProduct>()
                };
            }

            for (int i = 0; i < shoppingCartQuantities.Count; i++)
            {
                shopCart.Products[i].Quantity = shoppingCartQuantities[i];
            }

            SessionHelper.Set<Cart>(httpCtx.Session, "cart", shopCart);
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
