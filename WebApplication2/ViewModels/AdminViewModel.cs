using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int NumberOfOrders { get; set; }
        public int NumberOfOrdersSent { get; set; }
        public int NumberOfProducts { get; set; }
        public long NumberOfProductsSold { get; set; }
        public int ProductTotalStock { get; set; }
        public int NumberOfCustomers { get; set; }
    }
}
