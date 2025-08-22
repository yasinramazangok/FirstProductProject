using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.EntityLayer.DTOs.ProductDtos
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        [MaxLength(50)]
        public string SKU { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public double Weight { get; set; }

        [Required]
        [MaxLength(50)]
        public string Dimensions { get; set; } = null!;

        [Url]
        public string? ImageUrl { get; set; }                   // Optional at creation

        [MaxLength(200)]
        public string? Tags { get; set; }

        [Range(0, 100)]
        public decimal Discount { get; set; } = 0;

        [MaxLength(100)]
        public string? Supplier { get; set; }

        // Note: CreatedAt and Id are not provided by user
    }
}
