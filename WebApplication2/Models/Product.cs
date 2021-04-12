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
        [Required(ErrorMessage="Ange produktnamn.")]
        [MaxLength(50, ErrorMessage="Max 50 bokstäver är tillåtet.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Ange produktbeskrivning.")]
        [MaxLength(300, ErrorMessage = "Max 300 bokstäver är tillåtet.")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Ange pris.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Ange rabatt.")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "Ange bildUrl.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Ange modell.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Ange storlek.")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Ange kön.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Ange färg.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Ange lagersaldo.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Ange kategori.")]
        public string Category { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public virtual DateTime? ModifiedDate { get; set; }

        public OrderProduct OrderProduct { get; set; }

    }

}
