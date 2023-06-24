using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TKS.UseCases;

namespace TKS.Web.Pages.Category
{
    public class DetailsModel : PageModel
    {
        public readonly IGetCategory GetGetCategoryUseCase;
		public TKS.Core.Models.Category? Category { get; set; }

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
