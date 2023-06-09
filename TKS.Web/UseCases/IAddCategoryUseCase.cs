using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IAddCategoryUseCase
    {
        Task<(Category Category, bool success, string ErrorMessage)> ExecuteAsync(Category category);
    }
}
