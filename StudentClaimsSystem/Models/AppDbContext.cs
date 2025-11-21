using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;

public class AppDbContext : DbContext
{
    public DbSet<Module> Modules => Set<Module>();
    public DbSet<Claim> Claims => Set<Claim>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=claims.db");
}