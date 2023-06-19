﻿using Microsoft.EntityFrameworkCore;
using SkiaSharp;
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

        public async Task<(Category Category, bool Success, string ErrorMessage)>Add(Category category){
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

        public async Task<Category?>Get(int id)
        {
            return await Context.Category.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<(Category Category, bool Success, string ErrorMessage)>Edit(Category category)
        {

            try
            {
                Context.Category.Update(category);
				await Context.SaveChangesAsync();
                return (category, true, string.Empty);
			}
			catch (DbUpdateException /* ex */)
			{
				Logger.LogError($"Failed to update an instance of Category at: {DateTime.UtcNow}");
                return (new Category(), false, $"Failed to update an instance of Category at: {DateTime.UtcNow}");
			}
		}
    }
}
