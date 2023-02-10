namespace Inventory_Management_Software.Core.Entities;

public abstract class GuidEntity
{
    public Guid Id { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public DateTime CreatedDate { get; set; }
    
}