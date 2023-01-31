using Inventory_Management_Software.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_Software.Infrastructure;

public class GenericIMSContext : DbContext
{
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    
    
    protected GenericIMSContext()
    {
    }

    public GenericIMSContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<BaseEntity>).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<GuidEntity>).Assembly);
    }
}