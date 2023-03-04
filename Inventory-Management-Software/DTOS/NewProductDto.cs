namespace Inventory_Management_Software.DTOS {
    public class NewProductDto {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal MSRP { get; set; }

    }
}
