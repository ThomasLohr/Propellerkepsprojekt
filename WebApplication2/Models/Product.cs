using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Product
    {
        public Product(int id, string name, decimal price, string title)
        {
            Id = id;
            Name = name;
            Price = price;
            Title = title;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }
    }
}
