
using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IGetAllCategories
    {
        IQueryable<Category> Execute();
    }
}
