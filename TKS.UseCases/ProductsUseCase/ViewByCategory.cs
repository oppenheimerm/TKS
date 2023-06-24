
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.ProductsUseCase
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
