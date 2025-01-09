using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class WarehouseProduct
    {
        [Key]
        public Guid WarehouseProductId { get; set; } // Unique identifier

        [Required]
        public Guid WarehouseCode { get; set; } // Related warehouse

        [Required]
        public Guid ProductCode { get; set; } // Related product

        [Required]
        public int QuantityOnHand { get; set; } // Quantity available in this warehouse
    }
}
