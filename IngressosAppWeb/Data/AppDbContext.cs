using IngressosAppWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IngressosAppWeb.Data;

public class AppDbContext : IdentityDbContext
{
    public DbSet<Ingresso> Ingresso { get; set; }
    public DbSet<Tipo> Tipo { get; set; }
    public DbSet<Categoria> Categoria { get; set; }

    public AppDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string conn = config.GetConnectionString("Conn");

        optionsBuilder.UseNpgsql(conn);
    }
}
