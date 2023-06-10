using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.ProductsUseCase
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
