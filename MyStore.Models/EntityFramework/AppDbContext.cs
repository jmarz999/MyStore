using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Models.EntityFramework
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrders>().HasKey(x => new
            {
                x.ProductId,
                x.OrderId
            });

            modelBuilder.Entity<ProductOrders>().HasOne(x => x.Product).WithMany(x => x.ProductOrders).HasForeignKey(x => x.ProductId);
            
            modelBuilder.Entity<ProductOrders>().HasOne(x => x.Order).WithMany(x => x.ProductOrders).HasForeignKey(x => x.OrderId);
            
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrders> ProductOrders { get; set; }
    }
}
