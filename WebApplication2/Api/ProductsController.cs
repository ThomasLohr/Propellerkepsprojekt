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
    public class ProductsController : ControllerBase
    {
        private GenericRepository<Product> _productRepository = null;

        public ProductsController(GenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
