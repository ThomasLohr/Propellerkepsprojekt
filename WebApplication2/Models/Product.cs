using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Product : BaseEntity
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(300)]
        public string ProductDescription { get; set; }
        [Required]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public string ImageUrl { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Stock { get; set; }
    }

}
