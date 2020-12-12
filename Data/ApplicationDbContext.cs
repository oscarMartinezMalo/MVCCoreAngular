using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCCoreAngular.Data.Entities;

namespace MVCCoreAngular.Data
{
    public class ApplicationDbContext : IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Example how to seed the database for simples objects
            // dotnet ef migrations add SeedData
            base.OnModelCreating(builder);

            //builder.Entity<Order>()
            //    .HasData(new Order()
            //    {
            //        Id = 1,
            //        OrderDate = DateTime.UtcNow,
            //        OrderNumber = "12345"
            //    });
        }
    }
}
