using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IGetProductUseCase
    {
        Task<(Product Product, bool Success, string ErrorMessage)> ExecuteAsync(int id);
    }
}
