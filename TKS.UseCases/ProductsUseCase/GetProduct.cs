
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.ProductsUseCase
{
    public class GetProduct : IGetProductUseCase
    {
        private readonly IProductRepository ProductRepository;
        public GetProduct(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<(Product Product, bool Success, string ErrorMessage)> ExecuteAsync(int id)
        {
            var response = await ProductRepository.Get(id);
            return response;
        }
    }
}
