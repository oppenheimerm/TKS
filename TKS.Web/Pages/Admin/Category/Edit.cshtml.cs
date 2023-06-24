using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TKS.UseCases;

namespace TKS.Web.Pages.Category
{
    public class EditModel : PageModel
    {
		[BindProperty]
		public TKS.Core.Models.Category? Category { get; set; }

        readonly IGetCategory GetCategoryUseCase;
		readonly IEditCategory EditCategoryUseCase;

        public EditModel(IGetCategory getCategory, IEditCategory editCategory)
        {
            GetCategoryUseCase = getCategory;
			EditCategoryUseCase = editCategory;
        }
		public async Task<IActionResult> OnGetAsync(int id)
        {
            var category = await GetCategoryUseCase.ExecuteAsync(id);
            if (category is not null)
            {
                Category = category;
				return Page();
			}
            else
            {
                return NotFound();
            }
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid  || Category is null)
			{
				return Page();
			}

			var categoryToEdit = await GetCategoryUseCase.ExecuteAsync(Category.Id);
			if (categoryToEdit is not null)
			{
				//	We only want to update
				//		Name, CategoryDescription
				categoryToEdit.Name = Category.Name;
				categoryToEdit.CategoryDescription = Category.CategoryDescription;

				var status = await EditCategoryUseCase.ExecuteAsync(categoryToEdit);
				if (status.success)
				{
					return RedirectToPage("./Index");
				}
				else
				{
					return Page();
				}
			}
			else
			{
				return NotFound();
			}
		}
	}
}
