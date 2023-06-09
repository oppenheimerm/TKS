using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.ProductsUseCase
{
    public class AddProductPhotoUseCase : IAddProductPhotoUseCase
    {
        private readonly IPhotoFileRepository PhotoFileRepository;
        public AddProductPhotoUseCase(IPhotoFileRepository photoFileRepository)
        {
            PhotoFileRepository = photoFileRepository;
        }

        public async Task<(FileInfo FileInfo, bool Success, string ErrorMessage)> ExecuteAsync(IFormFile file, string folderName)
        {
            var response = await PhotoFileRepository.AddPhotoAsync(file, folderName);
            return response;
        }
    }
}
