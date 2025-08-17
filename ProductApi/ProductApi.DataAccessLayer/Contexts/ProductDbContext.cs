using Microsoft.EntityFrameworkCore;
using ProductApi.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.DataAccessLayer.Contexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        // DbSet for Product entity
        public DbSet<Product> Products { get; set; } = null!;

        // Optional: Fluent API configurations can be added here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique(); // SKU should be unique

            base.OnModelCreating(modelBuilder);
        }
    }
}
