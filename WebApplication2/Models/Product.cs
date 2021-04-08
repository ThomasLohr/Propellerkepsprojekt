using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Product : IModelDates
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter a product name.")]
        [MaxLength(50, ErrorMessage="Maximum 50 characters allowed.")]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Maximum 300 characters allowed.")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Please enter a price.")]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please enter a model.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please enter a size.")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Please enter a gender.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter a color.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please enter a stock amount.")]
        public int Stock { get; set; }
        public string Category { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public virtual DateTime? ModifiedDate { get; set; }

        public OrderProduct OrderProduct { get; set; }

    }

}
