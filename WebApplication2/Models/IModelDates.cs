using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    interface IModelDates
    {

        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }

    }
}
