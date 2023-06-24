

using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IGetProductUseCase
    {
        Task<(Product Product, bool Success, string ErrorMessage)> ExecuteAsync(int id);
    }
}
