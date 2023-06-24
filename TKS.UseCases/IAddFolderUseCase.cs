namespace TKS.UseCases
{
    public interface IAddFolderUseCase
    {
        Task<(DirectoryInfo DirectoryInfo, bool Success, string ErrorMessage)> ExecuteAsync();
    }
}
