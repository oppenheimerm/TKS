using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TKS.Web.Models;
using TKS.Web.UseCases;

namespace TKS.Web.Pages.Category
{
    public class DetailsModel : PageModel
    {
        public readonly IGetCategory GetGetCategoryUseCase;
		public Models.Category? Category { get; set; }

        public DetailsModel(IGetCategory getCategory)
        {
            GetGetCategoryUseCase = getCategory;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var getCategoryStatus = await GetGetCategoryUseCase.ExecuteAsync(id.Value);
            if(getCategoryStatus != null) {
                Category = getCategoryStatus;
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
