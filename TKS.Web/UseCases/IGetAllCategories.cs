using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IGetAllCategories
    {
        IQueryable<Category> Execute();
    }
}
