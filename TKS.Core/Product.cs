
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Core
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Maximum 300 character limit")]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum 100 character limit")]
        public string? Title { get; set; }

        [Required]
        public Category? Category { get; set; }
        
        public ProductPhoto? Photo { get; set; }
        public int? Likes { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
    }
}
