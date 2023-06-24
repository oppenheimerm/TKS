using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TKS.Core.Models;
using TKS.UseCases;

namespace TKS.Web.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IGetProductUseCase GetProductUseCase;

        public DetailsModel(IGetProductUseCase getProductUseCase)
        {
            GetProductUseCase = getProductUseCase;
        }

      public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await GetProductUseCase.ExecuteAsync(id.Value);
            if (product.Success)
            {
                Product = product.Product;
                return Page();
            }
            else 
            {
                return NotFound();
            }
        }
    }
}
