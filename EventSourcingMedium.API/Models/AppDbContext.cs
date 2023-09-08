using Microsoft.EntityFrameworkCore;

namespace EventSourcingMedium.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PostInformation> PostInformation { get; set; }
    }
}
