using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Warehouse
    {
        [Key]
        public Guid Code { get; set; } // Unique code for the warehouse

        [Required]
        public string Name { get; set; } // Name of the warehouse
    }
}
