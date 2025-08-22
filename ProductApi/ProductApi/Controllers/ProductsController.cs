using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.BusinessLayer.Abstracts;
using ProductApi.EntityLayer.DTOs.ProductDtos;
using ProductApi.EntityLayer.Models;
using System.Net.Mime;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound(new { message = $"ID'si {id} olan ürün bulunamadı." });
            
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto)
        {
            // Map CreateProductDto -> Product entity
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                SKU = dto.SKU,
                Brand = dto.Brand,
                Category = dto.Category,
                Weight = dto.Weight,
                Dimensions = dto.Dimensions,
                ImageUrl = dto.ImageUrl,
                Tags = dto.Tags,
                Discount = dto.Discount,
                Supplier = dto.Supplier,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            await _productService.AddAsync(product);

            // Map Product entity -> ProductDto for response
            var result = MapToProductDto(product);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

        }

        // PUT: api/products/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "Ürün ID'leri eşleşmiyor!" });

            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound(new { message = $"ID'si {id} olan ürün bulunamadı." });

            // Map UpdateProductDto -> existing Product entity
            existingProduct.Name = dto.Name;
            existingProduct.Description = dto.Description;
            existingProduct.Price = dto.Price;
            existingProduct.Stock = dto.Stock;
            existingProduct.Brand = dto.Brand;
            existingProduct.Category = dto.Category;
            existingProduct.Weight = dto.Weight;
            existingProduct.Dimensions = dto.Dimensions;
            existingProduct.ImageUrl = dto.ImageUrl;
            existingProduct.Tags = dto.Tags;
            existingProduct.Discount = dto.Discount;
            existingProduct.Supplier = dto.Supplier;
            existingProduct.IsActive = dto.IsActive;
            existingProduct.UpdatedAt = DateTime.Now;

            await _productService.UpdateAsync(existingProduct);

            // Map Product entity -> ProductDto for response
            var result = MapToProductDto(existingProduct);

            return Ok(result);
        }

        // DELETE: api/products/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            // Await the deletion operation, no return value
            await _productService.DeleteAsync(id);

            // If we reach here, deletion is assumed successful
            return NoContent(); // 204 No Content           
        }

        // GET: api/products/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetActiveProducts()
        {
            var activeProducts = await _productService.GetActiveProductsAsync();

            // Map Product entities -> ProductDto list
            var result = activeProducts.Select(MapToProductDto).ToList();

            return Ok(result);
        }

        // =============================
        // Helper method for manuel mapping Product -> ProductDto
        // =============================
        private ProductDto MapToProductDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                SKU = product.SKU,
                Brand = product.Brand,
                Category = product.Category,
                Weight = product.Weight,
                Dimensions = product.Dimensions,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                ImageUrl = product.ImageUrl,
                Tags = product.Tags,
                Discount = product.Discount,
                Supplier = product.Supplier
            };
        }
    }
}
