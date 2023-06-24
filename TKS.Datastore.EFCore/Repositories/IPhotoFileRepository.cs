using Microsoft.AspNetCore.Http;

namespace TKS.Datastore.EFCore
{
    public interface IPhotoFileRepository
    {
        Task<(FileInfo fileInfo, bool Success, string ErrorMessage)> AddPhotoAsync(IFormFile file, string folderName);
    }
}
