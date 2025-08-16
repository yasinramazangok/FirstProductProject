using ProductApi.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.DataAccessLayer.Abstracts
{
    public interface IProductRepository : IRepository<Product>
    {
        // Example of a product-specific method
        Task<List<Product>> GetActiveProductsAsync();
    }
}
