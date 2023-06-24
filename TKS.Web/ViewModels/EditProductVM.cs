using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TKS.Core.Models;

namespace TKS.Web.ViewModels
{
    public class EditProductVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Maximum 300 character limit")]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum 100 character limit")]
        public string? Title { get; set; }

        [Required]
        [ForeignKey("Categoy")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int? StockCount { get; set; } = 0;
    }
}
