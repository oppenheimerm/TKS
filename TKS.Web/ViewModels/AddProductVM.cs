using System.ComponentModel.DataAnnotations;
using TKS.Web.Models;

namespace TKS.Web.ViewModels
{
    public class AddProductVM
    {
        [Required]
        [MaxLength(300, ErrorMessage = "Maximum 300 character limit")]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum 100 character limit")]
        public string? Title { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public List<Category>? Categories { get; set; }

        public DateTime? Created { get; set; } = DateTime.Now;

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public IFormFile? Photo { get; set; }

        [Required]
        public int? StockCount { get; set; }
    }
}
