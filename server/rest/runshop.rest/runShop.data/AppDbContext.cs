using Microsoft.EntityFrameworkCore;
using runShop.Models.models;

namespace runShop.data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
