using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public string ImageUrl { get; set; }

        public string Model { get; set; }

        public string Size { get; set; }

        public string Gender { get; set; }

        public string Color { get; set; }

        public int Stock { get; set; }
    }

}
