using Inventory_Management_Software.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_Management_Software.Infrastructure.Data.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(p => p.Name).HasMaxLength(256);
        builder.Property(p => p.Description).HasMaxLength(1024);
        builder.Property(p => p.SKU).HasMaxLength(256);
        builder.HasIndex(p => p.SKU).IsUnique();
        builder.Property(p => p.Price).HasPrecision(18, 2);
        builder.Property(p => p.Cost).HasPrecision(18, 2);
        builder.Property(p => p.ManufacturerSuggestedRetailPrice).HasPrecision(18, 2);
        

        builder.HasOne<ProductCategory>(p => p.ProductCategory).WithMany(p => p.Products)
            .HasForeignKey(p => p.ProductCategoryId);

    }
}