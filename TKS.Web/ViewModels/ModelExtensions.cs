using TKS.Web.Models;

namespace TKS.Web.ViewModels
{
    /// <summary>
    /// Extension methods for ViewModels to Model.  Yes, I know I can use AutoMapper here,
    /// but I have triend to keeps it simple, and do it myself.
    /// </summary>
    public static class ModelExtensions
    {
        public static Category ToCategory(this AddCategoryVM vm)
        {
            return new Category
            {
                Name = vm.Name,
                CategoyCode = vm.CategoyCode,
                CategoryDescription = vm.CategoryDescription
            };
        }
    }
}
