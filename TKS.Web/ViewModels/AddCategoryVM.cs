using System.ComponentModel.DataAnnotations;

namespace TKS.Web.ViewModels
{
    public class AddCategoryVM
    {
        [Required]
        [MaxLength(35, ErrorMessage = "Maximum 35 characters long.")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(4, ErrorMessage = "Category Code must be 4 characters long"), MinLength(4)]
        public string? CategoyCode { get; set; }


        [MaxLength(100, ErrorMessage = "Maximum 100 characters long.")]
        public string? CategoryDescription { get; set; }
    }
}
