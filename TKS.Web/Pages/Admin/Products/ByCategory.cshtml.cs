using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TKS.Core.Models;
using TKS.UseCases;

namespace TKS.Web.Pages.Products
{
    public class ByCategoryModel : PageModel
    {
        private readonly IViewByCategory ViewByCategoryUseCase;
        private readonly IGetCategory GetCategoryUseCase;
        public List<Product>? Products { get; set; } = default;
        public TKS.Core.Models.Category? Category { get; set; }
        public ByCategoryModel(IViewByCategory viewByCategoryUseCase, IGetCategory getCategoryUseCase)
        {
            ViewByCategoryUseCase = viewByCategoryUseCase;
            GetCategoryUseCase = getCategoryUseCase;
        }
        public async Task<IActionResult> OnGetAsync(int Id)
        {
            var categoy = await GetCategoryUseCase.ExecuteAsync(Id);
            if(categoy != null)
            {
                Products = await ViewByCategoryUseCase.ExecuteAsync(Id);
                Category = categoy;
                return Page();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
