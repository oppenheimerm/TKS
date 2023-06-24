using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public interface IPhotoDbEntityRepository
    {
        Task<(PhotoEntity Photo, bool Success, string ErrorMessage)> Add(PhotoEntity photo);
    }
}
