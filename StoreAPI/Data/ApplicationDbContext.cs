using Microsoft.EntityFrameworkCore;
using StoreAPI.Models;

namespace StoreAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //TODO debug uncomment.  When testing make sure the connection string is the right one (dev versus docker image). Remove images from VS and docker app, clean solution if the connection strings doesn't seem to change.
            // Console.WriteLine($"ApplicationDbContext Connection String: {this.Database.GetDbConnection().ConnectionString}");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.CreatedDateTime)
                .HasDefaultValueSql("getdate()");
        }
    }
}

