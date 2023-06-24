using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public interface ICategoryRepository
    {
        Task<Category?> Get(int id);

		Task<(Category Category, bool Success, string ErrorMessage)> Add(Category category);
        Task<(Category Category, bool Success, string ErrorMessage)> Edit(Category category);

		IQueryable<Category> GetAll();
        Task<bool> IsCategoryCodeUnique(string categoryCode);
    }
}
