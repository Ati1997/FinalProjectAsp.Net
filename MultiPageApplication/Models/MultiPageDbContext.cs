using Microsoft.EntityFrameworkCore;
using MultiPageApplication.Models.DomainModels.ProductAggregates;

namespace MultiPageApplication.Models
{
    public class MultiPageDbContext : DbContext
    {
        public MultiPageDbContext(DbContextOptions options) : base(options)
        {
        }

        public MultiPageDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
