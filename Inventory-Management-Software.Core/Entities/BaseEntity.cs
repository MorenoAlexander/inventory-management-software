namespace Inventory_Management_Software.Core.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public DateTime CreatedDate { get; set; }
}