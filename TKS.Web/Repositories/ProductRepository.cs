using Microsoft.EntityFrameworkCore;
using TKS.Web.Data;
using TKS.Web.Models;

namespace TKS.Web.Repositories
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

        public async Task<(Product? Product, bool Success, string ErrorMessage)>Add(Product product)
        {
            try
            {
                Context.Product.Add(product);
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

        public async Task<(Product? Product, bool Success, string ErrorMessage)>Update(Product product)
        {
            try {
                Context.Product.Update(product);
                await Context.SaveChangesAsync();
                Logger.LogInformation($"Product with Id: {product.Id}, was updated at: {DateTime.UtcNow}");
                return (product, true, string.Empty);
            }
            catch(Exception ex) {
                Logger.LogError($"Failed to update product with id: {product.Id} at: {DateTime.UtcNow}");
                return (product, false, ex.ToString());
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Context.Product
                .Include( p => p.Photo).ThenInclude( f => f.Folder)
                .Include( c => c.Category)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
