using TKS.Web.Models;

namespace TKS.Web.UseCases
{
    public interface IAddPhotoDbEntityUseCase
    {
        Task<(PhotoEntity PhotoEntity, bool Success, string ErrorMessage)> ExecuteAsync(PhotoEntity photo);
    }
}
