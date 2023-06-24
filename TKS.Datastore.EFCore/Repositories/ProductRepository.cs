using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> Logger;
        private readonly ApplicationDbContext Context;
        public ProductRepository(ILogger<ProductRepository> logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }

        public async Task<(Product Product, bool Success, string ErrorMessage)>Add(Product product)
        {
            try
            {
                Context.Products.Add(product);
                await Context.SaveChangesAsync();
                Logger.LogInformation($"Product with Id: {product.Id}, added to database at: {DateTime.UtcNow}");
                return (product, true, string.Empty);
            }
            catch(Exception ex)
            {
                Logger.LogError($"Failed to add product to database. Timestamp : {DateTime.UtcNow}");
                return (product, false, ex.ToString());
            }
        }

        public async Task<(Product Product, bool Success, string ErrorMessage)>Update(Product product)
        {
            try {
                Context.Products.Update(product);
                await Context.SaveChangesAsync();
                Logger.LogInformation($"Product with Id: {product.Id}, was updated at: {DateTime.UtcNow}");
                return (product, true, string.Empty);
            }
            catch(Exception ex) {
                Logger.LogError($"Failed to update product with id: {product.Id} at: {DateTime.UtcNow}");
                return (product, false, ex.ToString());
            }
        }

        public async Task<(Product Product, bool Success, string ErrorMessage)>Get(int id)
        {
            //var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            var product = await Context.Products
                .Where(p => p.Id == id)
                .Include(x => x.Photo).ThenInclude(f => f.Folder)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if(product != null)
            {
                return(product, true, string.Empty);
            }
            else
            {
                return(new Product(), false, string.Empty);
            }
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await Context.Products
                .Include(p => p.Photo).ThenInclude(f => f.Folder)
                .Include(c => c.Category)
                .Where( x => x.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Context.Products
                .Include( p => p.Photo).ThenInclude( f => f.Folder)
                .Include( c => c.Category)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
