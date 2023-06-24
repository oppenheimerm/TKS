using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TKS.Core.Models;
using TKS.UseCases;
using TKS.Web.ViewModels;

namespace TKS.Web.Pages.Products
{
    public class EditModel : PageModel
    {
        readonly IUpdateProductUseCase UpdateProduct;
        readonly IGetProductUseCase GetProduct;


        public EditModel(IUpdateProductUseCase updateProduct, IGetProductUseCase getProduct)
        {
            UpdateProduct = updateProduct;
            GetProduct = getProduct;
        }

        [BindProperty]
        public EditProductVM Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await GetProduct.ExecuteAsync(id);
            if (product.Success  && product.Product is not null)
            {
                Product = product.Product.ToEditProductVM();
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            return RedirectToPage("./Index");
        }

    }
}
