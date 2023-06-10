using TKS.Web.Models;

namespace TKS.Web.Repositories
{
    public interface IProductRepository
    {
        Task<(Product? Product, bool Success, string ErrorMessage)> Add(Product product);
        Task<(Product? Product, bool Success, string ErrorMessage)> Update(Product product);
        Task<List<Product>> GetAllProducts();
    }
}
