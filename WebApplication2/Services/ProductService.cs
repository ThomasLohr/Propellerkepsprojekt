﻿using System;
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
    }
}