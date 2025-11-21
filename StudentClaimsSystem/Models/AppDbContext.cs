using Microsoft.EntityFrameworkCore;

namespace StudentClaimsSystem.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; } = null!;
        public DbSet<Claim> Claims { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=claims.db");
        }
    }
}