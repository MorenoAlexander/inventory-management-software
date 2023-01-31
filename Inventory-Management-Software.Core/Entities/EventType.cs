namespace Inventory_Management_Software.Core.Entities;

public class EventType : BaseEntity
{

    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
    

}