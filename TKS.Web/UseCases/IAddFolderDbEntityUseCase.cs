using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IAddFolderDbEntityUseCase
    {
        Task<(FolderEntity FolderDbEntity, bool Success, string ErrorMessage)> ExecuteAsync(FolderEntity folder);
    }
}
