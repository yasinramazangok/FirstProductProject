using ProductApi.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BusinessLayer.Abstracts
{
    public interface IProductService : IGenericService<Product>
    {
        // Example of a product-specific method
        Task<List<Product>> GetActiveProductsAsync();
    }
}
