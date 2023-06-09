using Microsoft.EntityFrameworkCore;
using TKS.Web.Data;
using TKS.Web.Models;

namespace TKS.Web.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> Logger;
        private readonly ApplicationDbContext Context;

        public CategoryRepository(ILogger<CategoryRepository> logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }

        public async Task<(Category, bool Success, string ErrorMessage)>Add(Category category){
            try
            {
                category.CategoyCode = category.CategoyCode.ToUpperInvariant();
                Context.Category.Add(category);
                await Context.SaveChangesAsync();
                Logger.LogInformation($"Category with Id: {category.Id}, added to database at: {DateTime.UtcNow}");
                return (category, true, string.Empty);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to add product to database. Timestamp : {DateTime.UtcNow}");
                return (category, false, ex.ToString());
            }
        }

        public IQueryable<Category>GetAll(){
            var categories = Context.Category
                .AsNoTracking();
            return categories;
        }

        public async Task<bool>IsCategoryCodeUnique(string categoryCode)
        {
            var codeInUse = await Context.Category
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoyCode == categoryCode.ToUpper());

            return (codeInUse == null) ? true : false;
        }
    }
}
