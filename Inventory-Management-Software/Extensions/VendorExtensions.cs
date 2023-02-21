using Inventory_Management_Software.Core.Entities;
using Inventory_Management_Software.DTOS;

namespace Inventory_Management_Software.Extensions;

public static class VendorExtensions
{
    public static Vendor UpdateFromDto(this Vendor vendor, NewVendorDto dto)
    {
        vendor.Name = dto.Name;
        vendor.Description = dto.Description;
        vendor.Website = dto.Website;
        return vendor;
    }
}
