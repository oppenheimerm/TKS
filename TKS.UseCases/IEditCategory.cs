using TKS.Core.Models;

namespace TKS.UseCases
{
	public interface IEditCategory
	{
		Task<(Category Category, bool success, string ErrorMessage)> ExecuteAsync(Category category);
	}
}
