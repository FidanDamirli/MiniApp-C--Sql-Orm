using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace MiniApp.DataAccess
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MiniApp;User Id=sa;Password=P@ssw0rd");
        }
    }
}


