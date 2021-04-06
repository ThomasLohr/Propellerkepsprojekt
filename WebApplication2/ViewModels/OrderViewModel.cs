using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public OrderProduct OrderProduct { get; set; }

        public Product Product { get; set; }
    }
}
