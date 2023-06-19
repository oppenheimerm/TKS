using TKS.Web.Repositories;

namespace TKS.Web.UseCases.CategoryUseCase
{
	public class EditCategory : IEditCategory
	{
		private readonly ICategoryRepository CategoryRepository;

		public EditCategory(ICategoryRepository categoryRepository)
		{
			CategoryRepository = categoryRepository;
		}

		public async Task<(Models.Category Category, bool success, string ErrorMessage)> ExecuteAsync(Models.Category category)
		{
			var response = await CategoryRepository.Edit(category);
			return response;
		}
	}
}
