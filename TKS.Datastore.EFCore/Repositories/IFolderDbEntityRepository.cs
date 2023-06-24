using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public interface IFolderDbEntityRepository
    {
        Task<(FolderEntity, bool Success, string ErrorMessage)> Add(FolderEntity folder);
    }
}
