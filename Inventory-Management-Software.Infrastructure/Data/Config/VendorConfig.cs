using Inventory_Management_Software.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_Management_Software.Infrastructure.Data.Config;

public class VendorConfig : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable("Vendors");
        builder.Property(v => v.Name).HasMaxLength(256);
        builder.Property(v => v.Description).HasMaxLength(256);
        builder.Property(v => v.Website).HasMaxLength(128);
    }
}