using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.EntityLayer.DTOs.ProductDtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }                   // Required to identify which product to update
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; } = null!;
        public string Category { get; set; } = null!;
        public double Weight { get; set; }
        public string Dimensions { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Tags { get; set; }
        public decimal Discount { get; set; }
        public string? Supplier { get; set; }
        public bool IsActive { get; set; }
        // Note: CreatedAt should not be updated
    }
}
