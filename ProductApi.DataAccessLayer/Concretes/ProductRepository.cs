using Microsoft.EntityFrameworkCore;
using ProductApi.DataAccessLayer.Abstracts;
using ProductApi.DataAccessLayer.Contexts;
using ProductApi.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.DataAccessLayer.Concretes
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {
        }

        // Example of a product-specific method
        public async Task<List<Product>> GetActiveProductsAsync()
        {
            return await _context.Set<Product>()
                                 .AsNoTracking()
                                 .Where(p => p.IsActive)
                                 .ToListAsync();
        }
    }
}
