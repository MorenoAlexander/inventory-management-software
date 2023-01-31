namespace Inventory_Management_Software.Core.Entities;

public class Vendor : GuidEntity
{

    public string Name { get; set; }
    
    public string Description { get; set; }

    public string Website { get; set; }

    public ICollection<Product> Products { get; set; } 

}