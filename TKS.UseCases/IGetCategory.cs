

using TKS.Core.Models;

namespace TKS.UseCases
{
	public interface IGetCategory
	{
		Task<Category?> ExecuteAsync(int id);
	}
}
