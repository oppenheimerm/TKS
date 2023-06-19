namespace TKS.Web.UseCases
{
	public interface IEditCategory
	{
		Task<(Models.Category Category, bool success, string ErrorMessage)> ExecuteAsync(Models.Category category);
	}
}
