using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using StudentClaimsSystem.Models;

namespace StudentClaimsSystem.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; } = null!;
        public DbSet<Claim> Claims { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=claims.db");
            }
        }
    }
}
