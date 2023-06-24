
using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IUpdateProductUseCase
    {
        Task<(Product Product, bool success, string ErrorMessage)> ExecuteAsync(Product product);
    }
}
