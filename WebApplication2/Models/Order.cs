using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order : IModelDates
    {
        public int Id { get; set; }
        public bool OrderSent { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? ShippedDate { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
