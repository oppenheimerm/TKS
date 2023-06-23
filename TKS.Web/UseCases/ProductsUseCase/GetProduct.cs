using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.ProductsUseCase
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
