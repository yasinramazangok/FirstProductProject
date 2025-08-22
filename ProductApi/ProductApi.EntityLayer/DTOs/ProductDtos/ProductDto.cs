using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductApi.EntityLayer.DTOs.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string SKU { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Category { get; set; } = null!;

        public double Weight { get; set; }

        public string Dimensions { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tags { get; set; }

        public decimal Discount { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Supplier { get; set; }
    }
}
