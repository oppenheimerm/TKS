
using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IGetAllProductUseCase
    {
        Task<List<Product>> ExecuteAsync();
    }
}
