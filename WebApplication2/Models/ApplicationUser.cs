using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ApplicationUser : IdentityUser, IModelDates
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }
        [MaxLength(11)]
        public string Zip { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        public List<Order> Orders { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public virtual DateTime? ModifiedDate { get; set; }
    }
}

