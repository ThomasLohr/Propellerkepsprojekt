using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public OrderProduct OrderProduct { get; set; }
        public string ProductName { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal? Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal? TotalPrice { get; set; }
        public List<OrderViewModel> OrderProductsList { get; set; }
        //Testing list for shoppingcart
        public List<int> shoppingCartIds { get; set; }
        public List<int> shoppingCartQuantities { get; set; }

    }
}
