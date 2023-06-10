
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TKS.Web.UseCases;
using TKS.Web.ViewModels;
using TKS.Web.Repositories;
using TKS.Web.Models;

namespace TKS.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IGetAllCategories GetAllCategoriesUseCase;
        private readonly IAddProductPhotoUseCase AddProductPhotoUseCase;
        private readonly IAddFolderUseCase AddFolderUseCase;
        private readonly IAddFolderDbEntityUseCase AddFolderDbEntityUseCase;
        private readonly IAddPhotoDbEntityUseCase AddPhotoDbEntityUseCase;
        private readonly IAddProductUseCase AddProductUseCase;
        private readonly IUpdateProductUseCase UpdateProductUseCase;

        public CreateModel(IGetAllCategories getAllCategoriesUseCase, IAddProductPhotoUseCase addProductPhotoUseCase,
            IAddFolderUseCase addFolderUseCase, IAddFolderDbEntityUseCase addFolderDbEntityUseCase, 
            IAddPhotoDbEntityUseCase addPhotoDbEntityUseCase, IAddProductUseCase addProductUseCase, IUpdateProductUseCase updateProductUseCase)
        {
            GetAllCategoriesUseCase = getAllCategoriesUseCase;
            AddProductPhotoUseCase = addProductPhotoUseCase;
            AddFolderUseCase = addFolderUseCase;
            AddFolderDbEntityUseCase = addFolderDbEntityUseCase;
            AddPhotoDbEntityUseCase = addPhotoDbEntityUseCase;
            AddProductUseCase = addProductUseCase;
            UpdateProductUseCase = updateProductUseCase;
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
          if (!ModelState.IsValid || Product == null || Product.Photo == null)
            {
                Product = new();
                Product.Categories = GetAllCategoriesUseCase.Execute().ToList();
                return Page();
            }

            // Got to add product!! 
            var product = await AddProductUseCase.ExecuteAsync(Product.ToProduct());
            if(product.success == true) {
                var folder = await AddFolderUseCase.ExecuteAsync();
                if (folder.Success)
                {
                    //  Add folder database entity
                    var folderDbEntity = await AddFolderDbEntityUseCase.ExecuteAsync(folder.DirectoryInfo.ToFolderDbEntity());
                    if (folderDbEntity.Success)
                    {

                        // Add Photo(physical)
                        var photo = await AddProductPhotoUseCase.ExecuteAsync(Product.Photo, folder.DirectoryInfo.Name);
                        if (photo.Success)
                        {
                            //  Add photoDb
                            PhotoEntity newPhoto = new PhotoEntity()
                            {
                                Name = photo.FileInfo.Name,
                                DisplayName = Path.GetFileNameWithoutExtension(photo.FileInfo.Name),
                                FolderId = folderDbEntity.FolderDbEntity.Id,
                            };

                            var photoEntity = await AddPhotoDbEntityUseCase.ExecuteAsync(newPhoto);
                            if (photoEntity.Success)
                            {
                                //  update the photofile
                                product.Product.Photo = photoEntity.PhotoEntity;
                                await UpdateProductUseCase.ExecuteAsync(product.Product);
                                return RedirectToPage("./Index");
                            }
                            else
                            {
                                //  Inernal server error
                                return StatusCode(500);
                            }
                        }
                        else
                        {
                            //  Inernal server error
                            return StatusCode(500);
                        }

                    }
                    else
                    {
                        //  Inernal server error
                        return StatusCode(500);
                    }


                }
                else
                {
                    //  Inernal server error
                    return StatusCode(500);
                }
            }
            else
            {
                Product = new();
                Product.Categories = GetAllCategoriesUseCase.Execute().ToList();
                return Page();
            }

        }
    }
}
