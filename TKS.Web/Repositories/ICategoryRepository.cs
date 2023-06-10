using TKS.Web.Models;

namespace TKS.Web.Repositories
{
    public interface ICategoryRepository
    {
        Task<(Category Category, bool Success, string ErrorMessage)> Add(Category category);
        IQueryable<Category> GetAll();
        Task<bool> IsCategoryCodeUnique(string categoryCode);
    }
}
