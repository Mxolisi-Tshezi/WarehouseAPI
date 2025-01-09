using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } // Unique order identifier

        [Required]
        public Guid ProductCode { get; set; } // Product being moved

        [Required]
        public Guid SourceWarehouseCode { get; set; } // Source warehouse

        [Required]
        public Guid DestinationWarehouseCode { get; set; } // Destination warehouse

        [Required]
        public int Quantity { get; set; } // Quantity to move

        public DateTime OrderDate { get; set; } = DateTime.Now; // Order creation date
    }
}
