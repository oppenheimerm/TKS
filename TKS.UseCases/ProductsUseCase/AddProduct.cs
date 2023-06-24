using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.ProductsUseCase
{
    public class AddProduct : IAddProductUseCase
    {
        private readonly IProductRepository ProductRepository;
        public AddProduct(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }
                
        public async Task<(Product Product, bool success, string ErrorMessage)>ExecuteAsync(Product product)
        {
            var response = await ProductRepository.Add(product);
            return response;
        }
    }
}
