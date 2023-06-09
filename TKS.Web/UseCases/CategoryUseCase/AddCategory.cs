using TKS.Web.Repositories;

namespace TKS.Web.UseCases.CategoryUseCase
{
    public class AddCategory : IAddCategoryUseCase
    {
        private readonly ICategoryRepository CategoryRepository;

        public AddCategory(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public async Task<(Models.Category Category, bool success, string ErrorMessage)> ExecuteAsync(Models.Category category)
        {
            var response = await CategoryRepository.Add(category);
            return response;
        }
    }
}
