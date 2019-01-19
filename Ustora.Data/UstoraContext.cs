using Microsoft.EntityFrameworkCore;
using Ustora.Data.Models;

namespace Ustora.Data
{
    public class UstoraContext : DbContext
    {
        public UstoraContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
