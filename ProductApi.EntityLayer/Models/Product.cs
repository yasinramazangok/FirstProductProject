using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.EntityLayer.Models
{
    public class Product
    {
        public int Id { get; set; }                   // Primary Key, auto-incremented in DB
        public string Name { get; set; } = null!;     // Required, max length can be enforced via EF Fluent API
        public string Description { get; set; } = null!; // Required, can be long text
        public decimal Price { get; set; }            // Use decimal for currency to avoid floating point errors
        public int Stock { get; set; }                // Current stock quantity
        public string SKU { get; set; } = null!;      // Stock Keeping Unit, should be unique
        public string Brand { get; set; } = null!;    // Brand name
        public string Category { get; set; } = null!; // Category name, can be normalized later
        public double Weight { get; set; }            // Weight in kg, double precision is enough
        public string Dimensions { get; set; } = null!; // Dimensions as string "LxWxH"
        public bool IsActive { get; set; } = true;   // Soft delete / active flag
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Store in UTC to avoid timezone issues
        public DateTime? UpdatedAt { get; set; }     // Nullable, set on update
        public string? ImageUrl { get; set; }        // Optional, can store CDN link
        public string? Tags { get; set; }            // Comma-separated tags, could be normalized later
        public decimal Discount { get; set; } = 0;   // Discount percentage, 0 means no discount
        public string? Supplier { get; set; }        // Optional supplier information
    }
}
