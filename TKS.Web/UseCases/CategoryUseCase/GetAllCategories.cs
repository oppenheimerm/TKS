using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.CategoryUseCase
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
