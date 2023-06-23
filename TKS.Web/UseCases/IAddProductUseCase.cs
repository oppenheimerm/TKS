using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IAddProductUseCase
    {
        Task<(Product Product, bool success, string ErrorMessage)> ExecuteAsync(Product product);
    }
}
