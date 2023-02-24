using System.ComponentModel.DataAnnotations;

namespace TheFisrtWebAPI.Models
{
    public class Products
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
    }
}
