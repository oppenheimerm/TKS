using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.ProductsUseCase
{
    public class AddProduct : IAddProductUseCase
    {
        private readonly IProductRepository ProductRepository;
        public AddProduct(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<(Product? Product, bool success, string ErrorMessage)>ExecuteAsync(Product product)
        {
            var response = await ProductRepository.Add(product);
            return response;
        }
    }
}
