using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IViewByCategory
    {
        Task<List<Product>> ExecuteAsync(int categoryId);
    }
}
