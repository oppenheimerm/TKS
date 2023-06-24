
using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IViewByCategory
    {
        Task<List<Product>> ExecuteAsync(int categoryId);
    }
}
