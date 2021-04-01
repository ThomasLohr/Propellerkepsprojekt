using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models; 

namespace WebApplication2.Repositories
{
    public interface IProductRepository
    {

        List<Product> ReadProducts(); // Returns a list of users
        void SaveProducts(List<Product> products); // Takes a list of users (and saves to a data source)
    }
}
