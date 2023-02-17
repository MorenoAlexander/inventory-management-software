using Inventory_Management_Software.Core.Entities;

namespace Inventory_Management_Software.DTOS;

public class NewVendorDto
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;
    
    public string Website { get; set; } = String.Empty;
    
    public NewVendorDto()
    {
    }

}
