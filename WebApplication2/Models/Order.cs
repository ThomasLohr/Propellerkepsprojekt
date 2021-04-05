using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public ApplicationUser  User { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Product> Products { get; set; }
        public bool OrderSent { get; set; }
    }
}
