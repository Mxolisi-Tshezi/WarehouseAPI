using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } // Unique identifier for the order

        [Required]
        public string ProductCode { get; set; } // Code of the product being moved

        [Required]
        public string SourceWarehouseCode { get; set; } // Code of the source warehouse

        [Required]
        public string DestinationWarehouseCode { get; set; } // Code of the destination warehouse

        [Required]
        public int Quantity { get; set; } // Quantity of the product being moved
    }
}
