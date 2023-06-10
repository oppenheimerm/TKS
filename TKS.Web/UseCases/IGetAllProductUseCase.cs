using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IGetAllProductUseCase
    {
        Task<List<Product>> ExecuteAsync();
    }
}
