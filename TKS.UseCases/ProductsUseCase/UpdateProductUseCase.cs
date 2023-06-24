
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.ProductsUseCase
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository ProductRepository;

        public UpdateProductUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<(Product Product, bool success, string ErrorMessage)> ExecuteAsync(Product product)
        {
            var response = await ProductRepository.Update(product);
            return response;
        }
    }
}
