using DataBase.DBServices;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Entities
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            modelBuilder.ApplyConfiguration(new ManagerConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfigurations());
            modelBuilder.ApplyConfiguration(new OrderDetailesConfigurations());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyEpicenter;Trusted_Connection=True;TrustServerCertificate=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetailes> OrdersDetailes { get; set; }

    }
}
