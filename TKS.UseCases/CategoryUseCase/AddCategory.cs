
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.CategoryUseCase
{
    public class AddCategory : IAddCategoryUseCase
    {
        private readonly ICategoryRepository CategoryRepository;

        public AddCategory(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public async Task<(Category Category, bool success, string ErrorMessage)> ExecuteAsync(Category category)
        {
            var response = await CategoryRepository.Add(category);
            return response;
        }
    }
}
