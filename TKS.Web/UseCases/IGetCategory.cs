using TKS.Web.Models;

namespace TKS.Web.UseCases
{
	public interface IGetCategory
	{
		Task<Category?> ExecuteAsync(int id);
	}
}
