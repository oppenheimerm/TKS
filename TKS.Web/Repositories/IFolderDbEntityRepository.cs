using TKS.Web.Models;

namespace TKS.Web.Repositories
{
    public interface IFolderDbEntityRepository
    {
        Task<(FolderEntity, bool Success, string ErrorMessage)> Add(FolderEntity folder);
    }
}
