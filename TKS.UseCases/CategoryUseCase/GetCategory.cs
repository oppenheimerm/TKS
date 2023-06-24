
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.CategoryUseCase
{
	public class GetCategory : IGetCategory
	{
		private readonly ICategoryRepository CategoryRepository;

		public GetCategory(ICategoryRepository categoryRepository)
		{
			CategoryRepository = categoryRepository;
		}

		public async Task<Category?> ExecuteAsync(int id)
		{
			return await CategoryRepository.Get(id);
		}
	}
}
