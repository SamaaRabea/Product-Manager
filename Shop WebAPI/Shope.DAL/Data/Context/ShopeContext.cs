using Microsoft.EntityFrameworkCore;
using Shop.DAL;

namespace Shope.DAL;

public class ShopeContext:DbContext
{
    public DbSet<Product> Product { get; set; }
    public virtual DbSet<Product_Version> Product_Version { get; set; }

    public ShopeContext(DbContextOptions<ShopeContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=Shope;Trusted_connection=True;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);

    }

   
}
