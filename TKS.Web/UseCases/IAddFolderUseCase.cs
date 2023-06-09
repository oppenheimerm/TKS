namespace TKS.Web.UseCases
{
    public interface IAddFolderUseCase
    {
        Task<(DirectoryInfo DirectoryInfo, bool Success, string ErrorMessage)> ExecuteAsync();
    }
}
