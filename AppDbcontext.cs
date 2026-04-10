using FoodOrderingSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem
{
    public class AppDbcontext : DbContext
    {

        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
        public DbSet<Model.User> Users { get; set; }

    }
}