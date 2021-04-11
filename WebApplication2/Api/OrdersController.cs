using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private GenericRepository<Order> _orderRepository = null;

        public OrdersController(GenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
