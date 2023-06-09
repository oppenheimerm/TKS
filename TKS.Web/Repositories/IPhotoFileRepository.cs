namespace TKS.Web.Repositories
{
    public interface IPhotoFileRepository
    {
        Task<(FileInfo fileInfo, bool Success, string ErrorMessage)> AddPhotoAsync(IFormFile file, string folderName);
    }
}
