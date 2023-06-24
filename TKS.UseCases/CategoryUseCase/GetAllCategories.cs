
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.CategoryUseCase
{
    public class GetAllCategories : IGetAllCategories
    {
        private readonly ICategoryRepository CategoryRepository;

        public GetAllCategories(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IQueryable<Category> Execute()
        {
            return CategoryRepository.GetAll();
        }
    }
}
