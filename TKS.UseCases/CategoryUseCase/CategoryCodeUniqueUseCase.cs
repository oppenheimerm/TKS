
using TKS.Datastore.EFCore;

namespace TKS.UseCases.CategoryUseCase
{
    public class CategoryCodeUniqueUseCase : ICategoryCodeUniqueUseCase
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryCodeUniqueUseCase(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public async Task<bool> ExecuteAsync(string categoryCode)
        {
            var response = await CategoryRepository.IsCategoryCodeUnique(categoryCode.ToUpperInvariant());
            return response;
        }
    }
}
