using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order
    {
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public int ItemAmount { get; set; }
        public bool OrderSent { get; set; }
    }
}
