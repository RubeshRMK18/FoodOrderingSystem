using FoodOrderingSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; } 

    }
}
