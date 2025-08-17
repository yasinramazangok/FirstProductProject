using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.EntityLayer.DTOs.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Category { get; set; } = null!;
        public double Weight { get; set; }
        public string Dimensions { get; set; } = null!;
        public string? ImageUrl { get; set; }           // Optional at creation
        public string? Tags { get; set; }
        public decimal Discount { get; set; } = 0;
        public string? Supplier { get; set; }
        // Note: CreatedAt and Id are not provided by user
    }
}
