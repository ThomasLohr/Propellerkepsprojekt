using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Cart
    {
        public List<OrderProduct> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
