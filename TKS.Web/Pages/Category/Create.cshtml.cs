using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TKS.Web.UseCases;
using TKS.Web.ViewModels;

namespace TKS.Web.Pages.Category
{
    public class CreateModel : PageModel
    {
        public readonly IAddCategoryUseCase AddCategoryUseCase;
        public readonly ICategoryCodeUniqueUseCase CategoryCodeUniqueUseCase;

        public CreateModel(IAddCategoryUseCase addCategoryUseCase, ICategoryCodeUniqueUseCase categoryCodeUniqueUseCase)
        {
            AddCategoryUseCase = addCategoryUseCase;
            CategoryCodeUniqueUseCase = categoryCodeUniqueUseCase;
        }

        [BindProperty]
        public AddCategoryVM AddCategoryVM { get; set; } = default!;

        public void OnGet()
        {
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || AddCategoryVM == null)
            {
                return Page();
            }

            // Check category code
            var categoryCodeUnique = await CategoryCodeUniqueUseCase.ExecuteAsync(AddCategoryVM.CategoyCode);
            if(categoryCodeUnique == false)
            {
                ModelState.AddModelError("", $"Category code: {AddCategoryVM.CategoyCode} is already in use.");
                return Page();
            }

            var status = await AddCategoryUseCase.ExecuteAsync(AddCategoryVM.ToCategory());
            if (status.success) {
                return RedirectToPage("./Index");
            }
            else {
                return Page();   
            }
            
        }
    }
}
