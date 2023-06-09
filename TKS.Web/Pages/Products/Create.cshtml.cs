using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TKS.Web.Models;
using TKS.Web.Data;
using TKS.Web.UseCases;
using TKS.Web.ViewModels;

namespace TKS.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IGetAllCategories GetAllCategoriesUseCase;
        private readonly IAddProductPhotoUseCase AddProductPhotoUseCase;
        private readonly IAddFolderUseCase AddFolderUseCase;

        public CreateModel(IGetAllCategories getAllCategoriesUseCase, IAddProductPhotoUseCase addProductPhotoUseCase,
            IAddFolderUseCase addFolderUseCase)
        {
            GetAllCategoriesUseCase = getAllCategoriesUseCase;
            AddProductPhotoUseCase = addProductPhotoUseCase;
            AddFolderUseCase = addFolderUseCase;
        }

        public IActionResult OnGet()
        {
            Product = new();
            Product.Categories = GetAllCategoriesUseCase.Execute().ToList();
            return Page();
        }

        [BindProperty]
        public AddProductVM Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Product == null)
            {
                Product = new();
                Product.Categories = GetAllCategoriesUseCase.Execute().ToList();
                return Page();
            }

            //   Add Folder
            var folder = await AddFolderUseCase.ExecuteAsync();
            if (folder.Success)
            {
                // Add Photo
                await AddProductPhotoUseCase.ExecuteAsync(Product.Photo, folder.DirectoryInfo.Name);

                //_context.Product.Add(Product);
                //await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            else
            {
                //  could not add folder
                return Page();
            }

        }
    }
}
