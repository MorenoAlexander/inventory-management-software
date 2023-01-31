namespace Inventory_Management_Software.Core.Entities;

public class ProductCategory : GuidEntity
{
    public string Name { get; set; }
    
    

    public ICollection<Product> Products { get; set; }
}