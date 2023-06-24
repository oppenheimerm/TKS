
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TKS.Core.Helpers;
using TKS.Core.Helpers.Imaging;

namespace TKS.Datastore.EFCore
{
    public class PhotoFileRepository : IPhotoFileRepository
    {
        private IWebHostEnvironment Environment;
        private ImageProcessor Processor;
        private readonly ILogger<PhotoFileRepository> Logger;

        public PhotoFileRepository(IWebHostEnvironment environment, ImageProcessor processor, ILogger<PhotoFileRepository> logger)
        {
            Environment = environment;
            Processor = processor;
            Logger = logger;
        }

        public async Task<(FileInfo fileInfo, bool Success, string ErrorMessage)> AddPhotoAsync(IFormFile file, string folderName)
        {
            try
            {
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(Environment.WebRootPath, Constants.ProductImageFolder, folderName, Path.GetFileName(fileName));

                if (File.Exists(filePath))
                {
                    filePath = Path.ChangeExtension(filePath, file.GetHashCode() + Path.GetExtension(filePath));
                }
                using (var imageStream = file.OpenReadStream())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    Processor.CreateThumbnails(imageStream, filePath);
                    await file.CopyToAsync(fileStream);
                }
                var fiileInfo = new FileInfo(filePath);
                Logger.LogInformation($"Photo: {file.FileName} added to folder: {folderName} at {DateTime.UtcNow}");
                return (new FileInfo(filePath), true, string.Empty);
            }
            catch(Exception ex)
            {
                return (new FileInfo(string.Empty), false, ex.ToString());
            }
        }
    }
}
