
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.ProductsUseCase
{
    public class GetAllProductUseCase : IGetAllProductUseCase
    {
        private readonly IProductRepository ProductRepository;
        public GetAllProductUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<List<Product>> ExecuteAsync()
        {
            return await ProductRepository.GetAllProducts();
        }
    }
}
