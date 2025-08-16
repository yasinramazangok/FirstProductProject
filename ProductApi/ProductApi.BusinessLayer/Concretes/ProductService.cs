using ProductApi.BusinessLayer.Abstracts;
using ProductApi.DataAccessLayer.Abstracts;
using ProductApi.DataAccessLayer.Contexts;
using ProductApi.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BusinessLayer.Concretes
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
            : base(productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetActiveProductsAsync()
        {
            return await _productRepository.GetActiveProductsAsync();
        }
    }
}
