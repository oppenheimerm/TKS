using Microsoft.Extensions.Hosting;
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
    }
}
