﻿using System.ComponentModel.DataAnnotations;


namespace TKS.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
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
