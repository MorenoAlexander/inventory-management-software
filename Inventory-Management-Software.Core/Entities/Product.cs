namespace Inventory_Management_Software.Core.Entities;

public class Product : GuidEntity
{
    public string SKU { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public decimal Price { get; set; } = 0m;
    public decimal Cost {get; set;} = 0m;
    public decimal ManufacturerSuggestedRetailPrice { get; set; } = 0m;
    

    public Guid? VendorId { get; set; }
    public Vendor? Vendor { get; set; }
    
    public Guid? ProductCategoryId { get; set; } 
    public ProductCategory? ProductCategory { get; set; }
    
    public Product()
    {
        Id = Guid.NewGuid();
    }
}