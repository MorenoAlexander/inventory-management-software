using Inventory_Management_Software.Core.Entities;
using Inventory_Management_Software.DTOS;

namespace Inventory_Management_Software.Extensions;
    public static class ProductExtensions {

        public static void UpdateFromDto(this Product product, NewProductDto dto)
        {
            product.SKU = dto.SKU ?? product.SKU;
            product.Name = dto.Name ?? product.Name;
            product.Description = dto.Description ?? product.Description;
            product.Price = dto.Price ?? product.Price;
            product.Cost = dto.Cost ?? product.Cost;
            product.ManufacturerSuggestedRetailPrice = dto.MSRP ?? product.ManufacturerSuggestedRetailPrice;
        } 
    }
