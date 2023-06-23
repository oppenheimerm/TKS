using Microsoft.AspNetCore.Mvc.RazorPages;
using TKS.Web.Models;
using TKS.Web.Data;
using TKS.Web.UseCases;
using Microsoft.AspNetCore.Authorization;

namespace TKS.Web.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IGetAllProductUseCase GetAllProductsUseCase;

        public IndexModel(IGetAllProductUseCase getAllProductsUseCase)
        {
            GetAllProductsUseCase = getAllProductsUseCase;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await GetAllProductsUseCase.ExecuteAsync();            
        }
    }
}
