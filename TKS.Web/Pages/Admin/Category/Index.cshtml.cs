using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TKS.UseCases;

namespace TKS.Web.Pages.Category
{
    public class IndexModel : PageModel
    {
        public readonly IGetAllCategories GetAllCategoriesUseCase;
        public IList<TKS.Core.Models.Category> Categories { get; set; } = default!;

        public IndexModel(IGetAllCategories getAllCategoriesUseCase)
        {
            GetAllCategoriesUseCase = getAllCategoriesUseCase;
        }

        public void OnGet()
        {
            Categories = GetAllCategoriesUseCase.Execute().ToList();
        }
    }
}
