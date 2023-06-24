

using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IAddFolderDbEntityUseCase
    {
        Task<(FolderEntity FolderDbEntity, bool Success, string ErrorMessage)> ExecuteAsync(FolderEntity folder);
    }
}
