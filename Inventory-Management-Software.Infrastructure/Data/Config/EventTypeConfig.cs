using Inventory_Management_Software.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_Management_Software.Infrastructure.Data.Config;

public class EventTypeConfig : IEntityTypeConfiguration<EventType> {
    public void Configure(EntityTypeBuilder<EventType> builder)
    {
        builder.ToTable("EventTypes");
        builder.Property(et => et.Name).HasMaxLength(256);
    }
}