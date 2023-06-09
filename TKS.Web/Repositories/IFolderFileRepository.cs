namespace TKS.Web.Repositories
{
    public interface IFolderFileRepository
    {
        Task<(DirectoryInfo directoryInfo, bool Success, string ErrorMessage)> CreateFolderAsync();
    }
}
