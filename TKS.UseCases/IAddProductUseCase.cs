using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IAddProductUseCase
    {
        Task<(Product Product, bool success, string ErrorMessage)> ExecuteAsync(Product product);
    }
}
