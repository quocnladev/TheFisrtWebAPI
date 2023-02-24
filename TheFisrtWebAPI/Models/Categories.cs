using System.ComponentModel.DataAnnotations;

namespace TheFisrtWebAPI.Models
{
    public class Categories
    {
        [Key]
        public Guid CateID { get; set; }

        [Required]
        [MaxLength(50)]
        public string CateName { get; set; }
    }
}
