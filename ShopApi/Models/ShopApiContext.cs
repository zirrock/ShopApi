using Microsoft.EntityFrameworkCore;

namespace ShopApi.Models
{
    public class ShopApiContext : DbContext
    {
        public ShopApiContext(DbContextOptions<ShopApiContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
