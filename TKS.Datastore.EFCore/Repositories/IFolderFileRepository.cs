namespace TKS.Datastore.EFCore
{
    public interface IFolderFileRepository
    {
        Task<(DirectoryInfo directoryInfo, bool Success, string ErrorMessage)> CreateFolderAsync();
    }
}
