using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.CategoryUseCase
{
	public class EditCategory : IEditCategory
	{
		private readonly ICategoryRepository CategoryRepository;

		public EditCategory(ICategoryRepository categoryRepository)
		{
			CategoryRepository = categoryRepository;
		}

		public async Task<(Category Category, bool success, string ErrorMessage)> ExecuteAsync(Category category)
		{
			var response = await CategoryRepository.Edit(category);
			return response;
		}
	}
}
