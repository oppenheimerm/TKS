using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TKS.Web.Models;
using TKS.Web.Data;
using TKS.Web.UseCases;

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
