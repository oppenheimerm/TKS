using Microsoft.AspNetCore.Http;

namespace TKS.UseCases
{
    public interface IAddProductPhotoUseCase
    {
        Task<(FileInfo FileInfo, bool Success, string ErrorMessage)> ExecuteAsync(IFormFile file, string folderName);
    }
}
