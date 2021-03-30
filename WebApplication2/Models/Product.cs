using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Product
    {
        public Product(int id, string name, decimal price, string details, string model, string color, string delivery)
        {
            Id = id;
            Name = name;
            Price = price;
            Details = details;
            Model = model;
            Color = color;
            Delivery = delivery;

            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Details { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Delivery { get; set; }
    }

}
