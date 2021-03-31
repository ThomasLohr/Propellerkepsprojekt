using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int OrderQty { get; set; }
        public bool OrderSent { get; set; }
        public virtual DateTime? RegistrationDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
