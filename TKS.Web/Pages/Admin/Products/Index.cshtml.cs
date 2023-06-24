using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using TKS.UseCases;
using TKS.Core.Models;

namespace TKS.Web.Pages.Products
{
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
