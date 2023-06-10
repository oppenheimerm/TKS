using TKS.Web.Models;

namespace TKS.Web.Repositories
{
    public interface IPhotoDbEntityRepository
    {
        Task<(PhotoEntity Photo, bool Success, string ErrorMessage)> Add(PhotoEntity photo);
    }
}
