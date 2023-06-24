using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IAddCategoryUseCase
    {
        Task<(Category Category, bool success, string ErrorMessage)> ExecuteAsync(Category category);
    }
}
