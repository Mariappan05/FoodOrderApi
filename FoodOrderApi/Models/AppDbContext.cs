using Microsoft.EntityFrameworkCore;

namespace FoodOrderApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
