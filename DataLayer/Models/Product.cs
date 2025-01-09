using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Product
    {
        [Key]
        public Guid Code { get; set; } // Unique code for the product

        [Required]
        public string Description { get; set; } // Description of the product
    }
}