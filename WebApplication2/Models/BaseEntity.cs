using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
