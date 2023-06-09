using TKS.Web.Models;

namespace TKS.Web.Repositories
{
    public interface IProductRepository
    {
        Task<(Product? Product, bool Success, string ErrorMessage)> Add(Product product);
    }
}
