using Inventory_Management_Software.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_Management_Software.Infrastructure.Data.Config;

public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.Property(pc => pc.Name).HasMaxLength(256);
        builder.HasMany<Product>(pc => pc.Products).WithOne(p => p.ProductCategory)
            .HasForeignKey(pc => pc.ProductCategoryId);
        
    }
}