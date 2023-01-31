namespace Inventory_Management_Software.Core.Entities;

public class Product : GuidEntity
{
    

    public string Name { get; set; }
    
    
    public Guid? ProductCategoryId { get; set; } 
    public ProductCategory ProductCategory { get; set; }
    
}