using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Models;

namespace ShopApi.Persistence.Contexts
{
    public class ShopApiContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopApiContext(DbContextOptions<ShopApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Client>().HasKey(p => p.Id);
            builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Client>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.Surname).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().HasMany(p => p.Orders).WithOne(p => p.Client).HasForeignKey(p => p.ClientId);
            builder.Entity<Client>().Property(p => p.Email).IsRequired();
            builder.Entity<Client>().Property(p => p.Phone);

            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().HasKey(p => p.Id);
            builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(p => p.ProductName).IsRequired().HasMaxLength(80);
            builder.Entity<Order>().Property(p => p.ProductQuantity).IsRequired();
            builder.Entity<Order>().Property(p => p.OrderDate).IsRequired();
            builder.Entity<Order>().Property(p => p.IsDeleted).IsRequired();
        }
    }
}
