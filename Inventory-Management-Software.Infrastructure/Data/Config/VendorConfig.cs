using System.Text.Json;
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

        builder.HasMany<Product>().WithOne(p => p.Vendor).HasForeignKey(p => p.VendorId);
        builder.HasData(SeedVendors());
    }

    private List<Vendor> SeedVendors()
    {
        using var streamReader = new StreamReader("./Seed/Vendor.json");
        var data = streamReader.ReadToEnd();
        var objects = JsonSerializer.Deserialize<List<Vendor>>(data) ?? new();
        return objects;
    }
}