
using TKS.Core.Models;

namespace TKS.UseCases
{
    public interface IAddPhotoDbEntityUseCase
    {
        Task<(PhotoEntity PhotoEntity, bool Success, string ErrorMessage)> ExecuteAsync(PhotoEntity photo);
    }
}
