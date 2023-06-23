using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.ProductsUseCase
{
    public class ViewByCategory : IViewByCategory
    {
        private readonly IProductRepository ProductRepository;

        public ViewByCategory(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<List<Product>> ExecuteAsync(int categoryId)
        {
            return await ProductRepository.GetProductsByCategory(categoryId);
        }
    }
}
