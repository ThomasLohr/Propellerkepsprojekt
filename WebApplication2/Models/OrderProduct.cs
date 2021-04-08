using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public ICollection<Product> Products { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
