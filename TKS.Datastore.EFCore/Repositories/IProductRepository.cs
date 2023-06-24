using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public interface IProductRepository
    {
        Task<(Product Product, bool Success, string ErrorMessage)> Add(Product product);
        Task<(Product Product, bool Success, string ErrorMessage)> Update(Product product);
        Task<(Product Product, bool Success, string ErrorMessage)> Get(int id);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsByCategory(int categoryId);
    }
}
